using System;
using System.Drawing;

namespace GeneticFlappyBird {
    class Obstacle {
		public double x; // position
		public readonly int h1; // top height
		public readonly int h2; // bottom height

		public Obstacle(double x, int h) {
			this.h1 = h; // remember the top height
			this.h2 = Constants.HEIGHT - h - Constants.OBSTACLE_GAP; // calculate the bottom height
			this.x = x; // remember the coordinate
		}

		// rendering
		public void Draw(Graphics g) {
			int x = (int)this.x - Constants.OBSTACLE_WIDTH / 2; // get the center
			int y1 = 0;
			int y2 = Constants.HEIGHT - this.h2;

			// draw obstacles (paint over rectangles)
			Brush brush = new SolidBrush(ColorTranslator.FromHtml("#00ff00"));
			g.FillRectangle(brush, x, y1, Constants.OBSTACLE_WIDTH, h1);
			g.FillRectangle(brush, x, y2, Constants.OBSTACLE_WIDTH, h2);

			Pen pen = Pens.Black;

			// draw obstacles (outline rectangles)
			g.DrawRectangle(pen, x, y1, Constants.OBSTACLE_WIDTH, h1);
			g.DrawRectangle(pen, x, y2, Constants.OBSTACLE_WIDTH, h2);
		}
	}
}
