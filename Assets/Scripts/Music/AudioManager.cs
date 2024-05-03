using UnityEngine;

namespace Music
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Source")] [SerializeField]
        private AudioSource musicSource;

        [SerializeField] private AudioSource sfxSource;

        [Header("Audio Clip")] public AudioClip fishGrabSfx;
        public AudioClip blockDestroySfx;
        public AudioClip onHurtSfx;
        public AudioClip onButtonClickSfx;
        public AudioClip tickAudioClipSfx;


        private void Start()
        {
            musicSource.Play();
        }

        public void PlaySfx(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}