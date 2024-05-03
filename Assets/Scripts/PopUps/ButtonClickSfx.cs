using Music;
using UnityEngine;
using Zenject;

namespace PopUps
{
    public class ButtonClickSfx : MonoBehaviour
    {
        [Inject] private AudioManager audioManager;

        public void OnButtonClick()
        {
            audioManager.PlaySfx(audioManager.onButtonClickSfx);
        }
    }
}