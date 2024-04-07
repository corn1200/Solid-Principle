using System;
using UnityEngine;

namespace InterfaceSegregation.BestPractice
{
    public class UnDeadEnemyUnit : MonoBehaviour, IMovable, IUnitStats
    {
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