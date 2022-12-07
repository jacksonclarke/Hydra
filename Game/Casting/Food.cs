using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Food : Actor
    {
        private int _points = 10;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Food(Point loc)
        {
            SetText("@");
            SetColor(Constants.RED); 
            Reset(loc);
        }

        /// <summary>
        /// Gets the points this food is worth.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetPoints()
        {
            return _points;
        }

        /// <summary>
        /// Selects a random position and points that the food is worth.
        /// </summary>
        public void Reset(Point loc)
        {
            // Random random = new Random();
            // _points = random.Next(9);
            // int x = random.Next(Constants.COLUMNS);
            // int y = random.Next(Constants.ROWS);
            // Point position = new Point(x, y);
            // Point position = loc.Scale(Constants.CELL_SIZE);
            SetPosition(loc);
        }
    }
}