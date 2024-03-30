namespace OpenClosed.BestPractice
{
    public class Rectangle : Shape
    {
        public float width;
        public float height;

        public override float CalculateArea()
        {
            return width * height;
        }
    }
}