namespace DependencyInversion.BestPractice
{
    public interface ISwitchable
    {
        public bool IsActive { get; }
        public void Activate();
        public void Deactivate();
    }
}