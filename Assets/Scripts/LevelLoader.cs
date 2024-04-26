using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        var levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}