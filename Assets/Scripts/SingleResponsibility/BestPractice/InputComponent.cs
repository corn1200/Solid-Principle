using UnityEngine;

namespace SingleResponsibility.BestPractice
{
    public class InputComponent
    {
        public float horizontalInput;
        public float verticalInput;

        public void InputAxis()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
    }
}