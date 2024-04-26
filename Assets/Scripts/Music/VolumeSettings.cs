using Constants;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Music
{
    public class VolumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsConsts.MusicVolume))
                LoadVolumeSettings();
            SetMusicVolume();
            SetSfxVolume();
        }

        public void SetMusicVolume()
        {
            var musicVolume = musicSlider.value;
            audioMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
            PlayerPrefs.SetFloat(PlayerPrefsConsts.MusicVolume, musicVolume);
        }

        public void SetSfxVolume()
        {
            var sfxVolume = sfxSlider.value;
            audioMixer.SetFloat("Sfx", Mathf.Log10(sfxVolume) * 20);
            PlayerPrefs.SetFloat(PlayerPrefsConsts.SfxVolume, sfxVolume);
        }

        private void LoadVolumeSettings()
        {
            musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefsConsts.MusicVolume);
            sfxSlider.value = PlayerPrefs.GetFloat(PlayerPrefsConsts.SfxVolume);
        }
    }
}