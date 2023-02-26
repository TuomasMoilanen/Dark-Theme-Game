using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Health Bar
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    #endregion

    #region Hearts collected
    private int heartsCol;
    [SerializeField] private TextMeshProUGUI calculator;
    #endregion

    #region Menu Navigation
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject soundMenu;
    #endregion

    public PlayerStats playerStats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                mainMenu.SetActive(true);
            }

        Hearts();
        calculator.text = heartsCol.ToString();
    }

    public void Hearts()
    {
        if (playerStats.health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        if (playerStats.health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        if (playerStats.health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        if (playerStats.health == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }

    public void HeartsCollected()
    {
        heartsCol++;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level0_Tutorial");
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        soundMenu.SetActive(false);
    }

    public void SoundOptions()
    {
        mainMenu.SetActive(false);
        soundMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        soundMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}