using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject screenToHide;
    [SerializeField] private GameObject screenToShow;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void ToTheNextScreen()
    {
        screenToHide.SetActive(false);
        screenToShow.SetActive(true);
    }

    public void BackToPrevious()
    {
        screenToHide.SetActive(true);
        screenToShow.SetActive(false);
    }
}