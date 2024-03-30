using UnityEngine;

namespace SingleResponsibility.WorstPractice
{
    public class Player : MonoBehaviour
    {
        private AudioSource _bounceSfx;
    
        private void Update()
        {
            // 키 입력 인식 기능
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
        
            // 이동 기능
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(moveDirection * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            // 효과음 재생 기능
            _bounceSfx.Play();
        }
    }
}
