using UnityEngine;

namespace SingleResponsibility.BestPractice
{
    public class AudioComponent
    {
        private AudioSource _bounceSfx;
        
        public void PlayBounce()
        {
            _bounceSfx.Play();
        }
    }
}