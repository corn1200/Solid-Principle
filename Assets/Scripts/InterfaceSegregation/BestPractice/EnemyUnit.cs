using UnityEngine;

namespace InterfaceSegregation.BestPractice
{
    public class EnemyUnit : MonoBehaviour, IDamageable, IMovable, IUnitStats
    {
        public float Health { get; set; }
        public int Defense { get; set; }

        public void Die()
        {
        }

        public void TakeDamage()
        {
        }

        public void RestoreHealth()
        {
        }

        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }

        public void GoForward()
        {
        }

        public void Reverse()
        {
        }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }
}