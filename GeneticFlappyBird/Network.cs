using System;
using System.Collections.Generic;

namespace GeneticFlappyBird {
	class Network {
		List<double[][]> layers; // list of weight matrices
		int[] sizes; // layer sizes
		List<double[]> signals; // list of signal values
		double[] inputSignals; // input signals

		public Network(int[] sizes, Random random) {
			layers = new List<double[][]>(); ;
			this.sizes = sizes;
			signals = new List<double[]>();
			inputSignals = new double[sizes[0]];

			for (int k = 0; k < sizes.Length - 1; k++) {
				int n = sizes[k + 1];
				int m = sizes[k];
				layers.Add(new double[n][]);
				signals.Add(new double[n]);

				for (int i = 0; i < n; i++) {
					layers[k][i] = new double[m];

					for (int j = 0; j < m; j++)
						layers[k][i][j] = random.NextDouble() * 2 - 1;
				}
			}
		}

		// getting network output
		public double[] GetOutput(double[] input) {
			for (int i = 0; i < input.Length; i++)
				inputSignals[i] = input[i]; // remember the input signal

			for (int k = 0; k < layers.Count; k++) {
				double[] output = new double[layers[k].Length]; // create an array to exit

				for (int i = 0; i < layers[k].Length; i++) {
					output[i] = 0;

					for (int j = 0; j < layers[k][i].Length; j++)
						output[i] += input[j] * layers[k][i][j]; // we multiply the matrix of weights and the vector

					// we activate with ReLU
					if (output[i] < 0)
						output[i] = 0;

					signals[k][i] = output[i]; // remember the signal
				}

				input = output; // updating the memorized entry
			}

			return input;
		}

		// copying the network
		public static Network Copy(Network network, Random random) {
			Network n = new Network(network.sizes, random);

			for (int k = 0; k < network.layers.Count; k++)
				for (int i = 0; i < network.layers[k].Length; i++)
					for (int j = 0; j < network.layers[k][i].Length; j++)
						n.layers[k][i][j] = network.layers[k][i][j];

			return n;
		}

		// crossing over
		public static Network CrossOver(Network n1, Network n2, Random random) {
			Network n = new Network(n1.sizes, random);

			for (int k = 0; k < n1.layers.Count; k++)
				for (int i = 0; i < n1.layers[k].Length; i++)
					for (int j = 0; j < n1.layers[k][i].Length; j++)
						n.layers[k][i][j] = random.NextDouble() > 0.5 ? n1.layers[k][i][j] : n2.layers[k][i][j]; // randomly choose the weights of one of the two parents

			return n; // and return the network
		}

		// mutation
		public static void Mutate(Network n, double p, Random random) {
			for (int k = 0; k < n.layers.Count; k++)
				for (int i = 0; i < n.layers[k].Length; i++)
					for (int j = 0; j < n.layers[k][i].Length; j++)
						if (random.NextDouble() < p) // with some probability we replace the weight with a random number
							n.layers[k][i][j] = random.NextDouble() * 2 - 1;
		}
	}
}
