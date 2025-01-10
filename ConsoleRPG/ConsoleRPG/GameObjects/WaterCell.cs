namespace Project1.GameObjects
{
    public class WaterCell : BaseCell
    {
        public WaterCell(int x, int y) : base(x, y)
        {
        }

        public override string GetDisplay()
        {
            return "~";
        }
    }
}
