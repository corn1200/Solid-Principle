namespace InterfaceSegregation.WorstPractice
{
    public interface IUnitStats
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void TakeDamage();
        public float MoveSpeed { get; set; }
        public void GoForward();
        public int Strength { get; set; }
        public int Dexterity { get; set; }
    }
}