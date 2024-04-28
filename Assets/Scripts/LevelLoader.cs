using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        var levelName = "Level" + levelId;
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}