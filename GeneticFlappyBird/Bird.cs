using System;
using System.Collections.Generic;
using System.Drawing;

namespace GeneticFlappyBird {
    class Bird {
		int x; // coordinate
		double y; // height
		double velocity; // speed
		int w; // width
		int h; // height
		Image img; // bird picture

		public Bird(Random random) {
			x = Constants.WIDTH / 3;
			y = Constants.HEIGHT / 2;
			velocity = 0; // the bird has no speed

			img = Constants.imgs[random.Next(Constants.imgs.Length)]; // choose a picture

			// remember the size of the picture
			w = img.Width;
			h = img.Height;
		}

		// flap
		public void Flap() {
			velocity = Constants.SPEED_VALUE;
		}

		// coordinate update
		public bool Move() {
			velocity += Constants.GRAVITY * Constants.dt; // update speed
			y += velocity * Constants.dt; // update the coordinate

			if (y >= Constants.BOTTOM) // if the bird fell
				return false; // then there is nowhere else to fly

			return true; // you can still fly
		}

		// collision check
		public bool Intersect(Obstacle obstacle) {
			double x1 = obstacle.x - Constants.OBSTACLE_WIDTH / 2;
			double x2 = obstacle.x + Constants.OBSTACLE_WIDTH / 2;

			if (x + w < x1 || x > x2) // if outside the left or right border of the obstacle
				return false; // it's not a collision

			double y1 = obstacle.h1;
			double y2 = Constants.HEIGHT - obstacle.h2;

			return this.y <= y1 || this.y + this.h >= y2; // check for upper and lower obstacles
		}

		// rendering an image
		public void Draw(Graphics g) {
			g.DrawImage(img, (int)x, (int)y);
		}

		// getting parameters for neural
		public double[] GetNearestParams(List<Obstacle> obstacles) {
			double x0 = 0;
			double y1 = 0;
			double y2 = 0;

			// we go over all obstacles
			for (int i = 0; i < obstacles.Count; i++) {
				x0 = obstacles[i].x + Constants.OBSTACLE_WIDTH / 2;
				y1 = obstacles[i].h1;
				y2 = Constants.HEIGHT - obstacles[i].h2;

				if (x <= x0 + 2) // if you find the nearest
					break; // then we leave
			}

			// get the normalized parameters to the obstacle
			return new double[] {
				(x0 - x) / Constants.WIDTH,
				(y1 - y) / Constants.HEIGHT,
				(y2 - y - h) / Constants.HEIGHT
			};
		}
	}
}
