using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour    // if need interesting read on GameManager Code https://github.com/joyixir/game-manager/blob/master/GameManager/Assets/Joyixir/GameManager/Scripts/GameManager.cs
{
    private static GameManager _instance;
    [Tooltip("Limited Frame Rate for the game cap limit from 30 to 120. Default of 60."), Range(30, 120)] public int limitedFPS = 60; 
    [Tooltip("If false Game Manager works in Debug mode. If true Game Manager will start the game as intended!")] public bool fullGameLaunch; // So debbuger does not need to find the Load scene everytime to do debugging from full launch
    private int sceneNum; // 0 = FullGameLaunch, 1 = Main Menu. Used to do "FullGameLaunch"


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

        Application.targetFrameRate = limitedFPS;
    }

    private void Start()
    {
        if (fullGameLaunch == true)
        {
            SceneManager.LoadScene(0);
            SceneManager.LoadScene(1);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
}