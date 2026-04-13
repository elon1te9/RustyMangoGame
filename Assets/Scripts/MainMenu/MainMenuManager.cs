using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject levelsPage;
    [SerializeField] private GameObject registerPage;
    [SerializeField] private GameObject loginPage;
    //[SerializeField] private GameObject leaderBoardPage;

    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private bool soundOn = true;

    private void Start()
    {
        ShowMainMenu();
        Time.timeScale = 1f;
    }

    private void HideAllPages()
    {
        mainMenuPage.SetActive(false);
        settingsPage.SetActive(false);
        levelsPage.SetActive(false);
        registerPage.SetActive(false);
        loginPage.SetActive(false);
        //leaderBoardPage.SetActive(false);
    }

    public void ShowMainMenu()
    {
        HideAllPages();
        mainMenuPage.SetActive(true);
    }

    public void ShowSettings()
    {
        HideAllPages();
        settingsPage.SetActive(true);
    }

    public void ShowLevels()
    {
        HideAllPages();
        levelsPage.SetActive(true);
    }

    public void ShowRegister()
    {
        HideAllPages();
        registerPage.SetActive(true);
    }

    public void ShowLogin()
    {
        HideAllPages();
        loginPage.SetActive(true);
    }

    public void StartLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void StartLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void StartLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    //public void ShowLeaderboard()
    //{
    //    Time.timeScale = 1f;
    //    leaderBoardPage.SetActive(true);
    //}

    public void ToggleSound()
    {
        soundOn = !soundOn;

        if (audioMixer != null)
        {
            audioMixer.SetFloat("MasterVolume", soundOn ? 0f : -80f);
        }
        else
        {
            AudioListener.volume = soundOn ? 1f : 0f;
        }
    }

}