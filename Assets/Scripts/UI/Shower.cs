using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public GameObject background;
    public GameObject endGameController;
    public AudioSource musicSource;

    string _text;
    int _gamesDone;
    int _lives;
    string _minutes;
    string _seconds;
    public void ShowGameInfo(string text, int gamesDone, int lives, string minutes, string seconds)
    {
        musicSource.clip = null;
        musicSource.Play();
        _text = text;
        _gamesDone = gamesDone;
        _lives = lives; 
        _minutes = minutes;
        _seconds = seconds;
        Invoke("xd", 2);
    }

    void xd()
    {
        Destroy(transform.GetChild(0).gameObject);
        background.SetActive(true);
        background.transform.GetChild(0).gameObject.SetActive(false);
        endGameController.SetActive(true);
        endGameController.GetComponent<EndGameController>().ShowData(new string[]
        {
                _gamesDone.ToString(), (PlayerPrefs.GetInt("Time") * 10 / 60) + ":" + (PlayerPrefs.GetInt("Time") * 10 % 60), _minutes + ":" + _seconds,
                _lives.ToString()
        }, _text);
    }
}
