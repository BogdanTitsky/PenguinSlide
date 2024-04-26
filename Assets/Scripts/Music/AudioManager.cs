using UnityEngine;

namespace Music
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Source")] [SerializeField]
        private AudioSource musicSource;

        [SerializeField] private AudioSource sfxSource;

        [Header("Audio Clip")] public AudioClip fishGrabSfx;


        private void Start()
        {
            musicSource.Play();
        }

        public void PlatSfx(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}