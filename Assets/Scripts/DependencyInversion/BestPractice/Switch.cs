using UnityEngine;

namespace DependencyInversion.BestPractice
{
    public class Switch:MonoBehaviour
    {
        public ISwitchable client;

        public void Toggle()
        {
            if (client.IsActive)
            {
                client.Deactivate();
            }
            else
            {
                client.Activate();
            }
        }
    }
}