using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public GameObject menu;
    public List<Setting> settings;
    public TextMeshProUGUI backButton;
    public AudioSource musicSource;
    bool isMusicChanged;

    public void BackButtonClicked()
    {
        backButton.fontStyle = FontStyles.Normal;
        MenuSoundManager.Instance.PlayClickSfx();
        foreach (Setting setting in settings)
        {
            if (setting.namee == "Music")
            {
                if (setting.val != PlayerPrefs.GetInt("Music")) isMusicChanged = true;
                else isMusicChanged = false;
            }
            PlayerPrefs.SetInt(setting.namee, setting.val);
        }

        gameObject.SetActive(false);
        menu.SetActive(true);
        musicSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10 * PlayerPrefs.GetInt("Music");
        if (musicSource.volume == 0)
        {
            if ((float)PlayerPrefs.GetInt("Volume") / 10 != 0)
            {
                musicSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10;
                musicSource.clip = MenuSoundManager.Instance.lamp;
                musicSource.Play();
            }
        }
        else
        {
            musicSource.clip = menu.GetComponent<MenuController>().menuMusic;
            if(isMusicChanged)
                musicSource.Play();
        }

    }
}
