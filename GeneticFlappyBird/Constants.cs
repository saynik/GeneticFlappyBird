using System.Drawing;

namespace GeneticFlappyBird {
	class Constants {
		public const int WIDTH = 480; // window width
		public const int HEIGHT = 640; // window height
		public const int BOTTOM = HEIGHT; // the lower limit for the bird

		public const int OBSTACLE_WIDTH = 80; // width of obstacles
		public const int OBSTACLE_GAP = 160; // clearance between obstacles
		public const int MINIMUM_OBSTACLE_DISTANCE = WIDTH; // the minimum distance for a new obstacle to appear
		public const double OBSTACLE_DX = 1; // speed of obstacles
		public const double OBSTACLE_INITIAL_DX = 2; // initial speed of obstacles

		public const int GRAVITY = 10; // gravity
		public const int SPEED_VALUE = -40; // bird speed
		public const double dt = 0.25; // time step

		// pictures of birds for drawing
		public static Bitmap[] imgs = {
			Properties.Resources.bird1,
			Properties.Resources.bird2,
			Properties.Resources.bird3,
			Properties.Resources.bird4,
			Properties.Resources.bird5
		};
	}
}
