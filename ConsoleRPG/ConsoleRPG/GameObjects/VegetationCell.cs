namespace Project1.GameObjects
{
    public class VegetationCell : BaseCell
    {
        public VegetationCell(int x, int y) : base(x, y)
        {
        }

        public override string GetDisplay()
        {
            return "#";
        }
    }
}
