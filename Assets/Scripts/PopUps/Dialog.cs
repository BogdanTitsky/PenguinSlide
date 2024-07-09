using TMPro;
using UnityEngine;

namespace PopUps
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private GameObject popUp;
        [SerializeField] private bool pauseGame = true;
        [SerializeField] private TextMeshProUGUI textComponent;
        [SerializeField] private string[] textLines;

        private int currentLineIndex;


        private void Awake()
        {
            PauseGame();
            textComponent.text = textLines[currentLineIndex];
        }

        private void PauseGame()
        {
            if (pauseGame) Time.timeScale = 0;
        }

        public void SetText()
        {
            if (currentLineIndex < textLines.Length - 1)
            {
                currentLineIndex++;
                textComponent.text = textLines[currentLineIndex];
            }
            else
            {
                HidePopUp();
            }
        }

        private void HidePopUp()
        {
            Time.timeScale = 1;
            popUp.SetActive(false);
        }
    }
}