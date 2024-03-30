namespace InterfaceSegregation.BestPractice
{
    public interface IMovable
    {
        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }
        public void GoForward();
        public void Reverse();
    }
}