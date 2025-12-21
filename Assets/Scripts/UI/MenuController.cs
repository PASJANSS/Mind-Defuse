using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject help;
    public GameObject settings;
    public GameObject scores;
    public AudioSource musicSource;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public TextMeshProUGUI helpText;
    public TextMeshProUGUI playText;
    public TextMeshProUGUI settingsText;

    private void Start()
    {
        //default settings
        if (!PlayerPrefs.HasKey("Modules")) PlayerPrefs.SetInt("Modules", 5);
        if (!PlayerPrefs.HasKey("Volume")) PlayerPrefs.SetInt("Volume", 5);
        if (!PlayerPrefs.HasKey("Music")) PlayerPrefs.SetInt("Music", 1);
        if (!PlayerPrefs.HasKey("Time")) PlayerPrefs.SetInt("Time", 42);
        if (!PlayerPrefs.HasKey("Lives")) PlayerPrefs.SetInt("Lives", 3);
        musicSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10 * PlayerPrefs.GetInt("Music");
        musicSource.clip = menuMusic;
        if (musicSource.volume == 0)
        {
            if ((float)PlayerPrefs.GetInt("Volume") / 10 != 0)
            {
                musicSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10;
                musicSource.clip = MenuSoundManager.Instance.lamp;
            }
        }
        musicSource.Play();
    }
    public void PlayButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        musicSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10 * PlayerPrefs.GetInt("Music");
        musicSource.clip = gameMusic;
        musicSource.Play();
        transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    private void OnEnable()
    {
        helpText.fontStyle = FontStyles.Normal;
        playText.fontStyle = FontStyles.Normal;
        settingsText.fontStyle = FontStyles.Normal;
    }

    public void ScoresButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        scores.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HelpButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        help.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        Application.Quit();
    }

    public void SettingsButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        settings.SetActive(true);
        gameObject.SetActive(false);
    }
}
