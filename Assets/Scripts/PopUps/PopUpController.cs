using DG.Tweening;
using UnityEngine;

namespace PopUps
{
    public class PopUpController : MonoBehaviour
    {
        [SerializeField] private GameObject popUp;
        [SerializeField] private GameObject popUpView;
        [SerializeField] private bool pauseGame;
        private readonly float duration = 0.5f;

        private void OnEnable()
        {
            popUpView.transform.localScale = Vector3.zero;
        }

        public void ShowPopUp()
        {
            popUp.SetActive(true);
            popUpView.transform.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(PauseGame);
        }

        public void HidePopUp()
        {
            Time.timeScale = 1;
            popUpView.transform.DOScale(0, duration).SetEase(Ease.InBack)
                .OnComplete(() => popUp.SetActive(false));
        }

        private void PauseGame()
        {
            if (pauseGame) Time.timeScale = 0;
        }
    }
}