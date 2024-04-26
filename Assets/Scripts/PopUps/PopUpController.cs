using UnityEngine;
using DG.Tweening; // Підключення простору імен DOTween

namespace PopUps
{
    public class PopUpController : MonoBehaviour
    {
        [SerializeField] private GameObject popUp;
        [SerializeField] private GameObject popUpView;
        private float duration = 0.5f; 

        private void Start()
        {  
            popUpView.transform.localScale = Vector3.zero; 
        }

        public void ShowPopUp()
        {
            popUp.SetActive(true);
            popUpView.transform.DOScale(1, duration).SetEase(Ease.OutBack); 
        }

        public void HidePopUp()
        {
            popUpView.transform.DOScale(0, duration).SetEase(Ease.InBack)
                .OnComplete(() => popUp.SetActive(false));
        }
    }
}