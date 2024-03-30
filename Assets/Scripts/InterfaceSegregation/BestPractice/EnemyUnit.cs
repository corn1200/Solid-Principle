using UnityEngine;

namespace InterfaceSegregation.BestPractice
{
    public class EnemyUnit : MonoBehaviour, IDamageable, IMovable, IUnitStats
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreHealth()
        {
            throw new System.NotImplementedException();
        }

        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }
        public void GoForward()
        {
            throw new System.NotImplementedException();
        }

        public void Reverse()
        {
            throw new System.NotImplementedException();
        }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }
}