using UnityEngine;

namespace DependencyInversion.WorstPractice
{
    public class Switch : MonoBehaviour
    {
        public Door Door;
        public bool IsActivated;

        public void Toggle()
        {
            if (IsActivated)
            {
                IsActivated = false;
                Door.Close();
            }
            else
            {
                IsActivated = true;
                Door.Open();
            }
        }
    }
}