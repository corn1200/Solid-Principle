using UnityEngine;

namespace DependencyInversion.BestPractice
{
    public class Door : MonoBehaviour, ISwitchable
    {
        private bool _isActive;
        public bool IsActive => _isActive;
        
        public void Activate()
        {
            _isActive = true;
            Debug.Log("The door is open.");
        }

        public void Deactivate()
        {
            _isActive = false;
            Debug.Log("The door is closed.");
        }
    }
}