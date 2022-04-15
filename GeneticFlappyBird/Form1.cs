using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeneticFlappyBird {
    public partial class Form1 : Form {
		struct Entity {
			public Network network; // neural network
			public Bird bird; // bird
			public int score; // score
        }

		Random random; // random number generator
		Bitmap bitmap; // picture to draw
		Graphics g; // graphics

		Entity[] population; // population
		List<Obstacle> obstacles; // obstacles

		int score; // score
		int epoch; // generation

		int total; // total number of birds
		int distance; // distance
		double dx; // shift

		bool isStarted; // is it started

		public Form1() {
            InitializeComponent();

			Height = Constants.HEIGHT + 23;
			Width = Constants.WIDTH + 189;
			random = new Random(); // create a random number generator
			bitmap = new Bitmap(Canvas.Width, Canvas.Height); // create an image
			g = Graphics.FromImage(bitmap); // creating graphics
			isStarted = false; // not started
        }

		// adding obstacles
		void AddObstacle(List<Obstacle> obstacles) {
			int y = random.Next(50, Constants.HEIGHT - Constants.OBSTACLE_GAP - 100); // generating height
			obstacles.Add(new Obstacle(Constants.WIDTH, y)); // add an obstacle
		}

		// updating obstacles
		void UpdateObstacles(List<Obstacle> obstacles, double dx) {
			for (int i = 0; i < obstacles.Count; i++)
				obstacles[i].x -= dx; // moving obstacles

			while (obstacles.Count > 0 && obstacles[0].x < -Constants.OBSTACLE_WIDTH / 2) // we remove obstacles that have gone abroad
				obstacles.RemoveAt(0);

			// if there are no visible obstacles
			if (obstacles.Count == 0 || (Constants.WIDTH - obstacles[obstacles.Count - 1].x > Constants.MINIMUM_OBSTACLE_DISTANCE))
				AddObstacle(obstacles); // then we add a new one
		}

		// flap formation
		void MakeFlap(Bird bird, List<Obstacle> obstacles, Network network) {
			double[] input = bird.GetNearestParams(obstacles); // we form data before the obstacle
			double output = network.GetOutput(input)[0]; // we get the network output

			if (output > 0.5) // if needed
				bird.Flap(); // then we flap
		}

		// execution of the genetic algorithm
		void MakeGenetic() {
			double mutationRate = (double)MutationProbabilityBox.Value; // we get the probability of mutation
			int winners = (int)TopCountBox.Value; // we get the number of winners

			Array.Sort(population, (a, b) => { return b.score - a.score; }); // we sort the population by decreasing fitness

			if (population[0].score >= score) {
				score = population[0].score; // updating the best result
			}

			for (int i = 0; i < population.Length; i++) {
				if (i < winners) { // if the winners
					population[i].network = Network.Copy(population[i].network, random); // then we save them as they are
				}
				else {
					// otherwise we choose two parents among the winners
					Network parentA = population[random.Next(winners)].network;
					Network parentB = population[random.Next(winners)].network;

					population[i].network = Network.CrossOver(parentA, parentB, random); // create offspring
					Network.Mutate(population[i].network, mutationRate, random); // and mutate
				}

				population[i].bird = new Bird(random); // create a new bird
			}
		}

		// timer tick
		private void timer_Tick(object sender, EventArgs e) {
			g.Clear(Color.White); // we clear the screen
			int firstIndex = -1; // first live bird index

			for (int i = 0; i < population.Length; i++) {
				if (population[i].bird == null) // if there is no bird
					continue; // then we go further

				MakeFlap(population[i].bird, obstacles, population[i].network); // make a flap

				if (firstIndex == -1) // if no bird has been found yet
					firstIndex = i; // then we remember the index

				population[i].bird.Draw(g); // draw the bird

				int index = -1; // looking for the obstacle index with which the bird intersects

				for (int j = 0; j < obstacles.Count; j++)
					if (population[i].bird.Intersect(obstacles[j])) // if intersects
						index = j; // remember the index

				if (!population[i].bird.Move() || index != -1) { // if the bird cannot fly or has collided
					population[i].score = distance; // remember the distance
					population[i].bird = null; // remove the bird
					total--; // we reduce the number of live birds
				}
			}

			for (int i = 0; i < obstacles.Count; i++)
				obstacles[i].Draw(g); // draw obstacles
			
			UpdateObstacles(obstacles, dx); // updating obstacles
			distance++; // increase the distance traveled

			if (distance % 1000 == 0) // every 1000 iterations
				dx += Constants.OBSTACLE_DX; // increasing the speed

			Font font = new Font("Consolas", 16);
			g.DrawString("Generation: " + epoch, font, Brushes.Black, 10, 5);
			g.DrawString("Alive: " + total + "/" + population.Length, font, Brushes.Black, 10, 30);
			g.DrawString("Distance: " + distance, font, Brushes.Black, 10, 55);
			g.DrawString("Best: " + Math.Max(distance, score), font, Brushes.Black, 10, 80);

			Canvas.Image = bitmap; // update the picture

			if (total == 0) { // if there are no living birds left
				MakeGenetic(); // we start genetics

				obstacles.Clear(); // removing obstacles
				AddObstacle(obstacles); // adding a new obstacle

				total = population.Length; // we start with the whole population
				distance = 0; // reset the distance
				dx = Constants.OBSTACLE_INITIAL_DX; // we reset the speed
				epoch++; // increase the number of epochs
			}
		}

		// launching the game
		void Start() {
			population = new Entity[(int)PopulationSizeBox.Value]; // creating a population
			score = 0; // reset the score
			epoch = 0; // reset the epoch

			for (int i = 0; i < population.Length; i++) {
				population[i] = new Entity { // create a new entity
					network = new Network(new int[] { 3, 20, 1 }, random),
					score = 0,
					bird = new Bird(random)
				};
			}

			obstacles = new List<Obstacle>(); // we create obstacles
			AddObstacle(obstacles); // add an obstacle

			total = population.Length; // start with the full population
			distance = 0; // the distance has not been covered
			dx = Constants.OBSTACLE_INITIAL_DX; // set the initial speed
		}

		// click on the start button
		private void RunBtn_Click(object sender, EventArgs e) {
			if (isStarted) { // if already running
				timer.Stop(); // stop the timer
				RunBtn.Text = "Run";
			}
			else {
				Start(); // otherwise, run
				timer.Start(); // start the timer
				RunBtn.Text = "Stop";
			}

			isStarted = !isStarted; // change the launch state flag
		}
    }
}
