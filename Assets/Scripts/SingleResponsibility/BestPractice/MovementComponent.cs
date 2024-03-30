using UnityEngine;

namespace SingleResponsibility.BestPractice
{
    public class MovementComponent
    {
        private Vector3 _moveDirection;

        public void Move(Transform transform, float horizontalInput, float verticalInput)
        {
            _moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(_moveDirection * Time.deltaTime);
        }
    }
}