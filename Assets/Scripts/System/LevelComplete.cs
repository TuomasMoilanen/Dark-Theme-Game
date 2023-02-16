using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string levelName;

    public void loadScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
