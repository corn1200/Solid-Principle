using UnityEngine;

namespace LiskovsSubstitution.WorstPractice
{
    public class Navigator
    {
        public void Move(Vehicle vehicle)
        {
            // 상속을 받아버려서, 기차도 회전이 됨
            Train train = vehicle as Train;
            train.TurnLeft();
            
            vehicle.GoForward();
            vehicle.TurnLeft();
            vehicle.GoForward();
            vehicle.TurnRight();
            vehicle.GoForward();
        }
    }
}