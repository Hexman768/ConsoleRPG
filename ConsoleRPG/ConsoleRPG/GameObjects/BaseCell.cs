namespace Project1.GameObjects
{
    /// <summary>
    /// This is the base class that all visible objects on the <see cref="GameBoard"/> will derive base behavior.
    /// </summary>
    public class BaseCell
    {
        private int x;
        private int y;

        /// <summary>
        /// Constructs an instance of the <see cref="BaseCell"/> object.
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public BaseCell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns the X value of the <see cref="BaseCell"/>.
        /// </summary>
        public int X { get { return x; } set { x = value; } }

        /// <summary>
        /// Returns the Y value of the <see cref="BaseCell"/>.
        /// </summary>
        public int Y { get { return y; } set { y = value; } }

        /// <summary>
        /// This method returns the display of the <see cref="BaseCell"/> to be shown on the virtual game board.
        /// </summary>
        /// <returns>string</returns>
        public virtual string GetDisplay()
        {
            return ".";
        }
    }
}
