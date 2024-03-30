using System;
using UnityEngine;

namespace SingleResponsibility.BestPractice
{
    public class Player : MonoBehaviour
    {
        AudioComponent _audioComponent;
        InputComponent _inputComponent;
        MovementComponent _movementComponent;

        private void Start()
        {
            _audioComponent = new AudioComponent();
            _inputComponent = new InputComponent();
            _movementComponent = new MovementComponent();
        }

        private void Update()
        {
            _inputComponent.InputAxis();
            _movementComponent.Move(transform, 
                _inputComponent.horizontalInput, _inputComponent.verticalInput);
        }

        private void OnTriggerEnter(Collider other)
        {
            _audioComponent.PlayBounce();
        }
    }
}