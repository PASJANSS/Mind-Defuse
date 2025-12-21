using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public List<TextMeshProUGUI> labels = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> buttons = new List<TextMeshProUGUI>();
    public TextMeshProUGUI title;
    public TextMeshProUGUI modules;
    public TextMeshProUGUI time;
    public void ShowData(string[] data, string titleText)
    {
        title.text = titleText;
        for(int i = 0; i < labels.Count; i++)
        {
            labels[i].text = data[i];
        }
    }

    private void OnEnable()
    {
        foreach (var button in buttons) button.fontStyle = FontStyles.Normal;
    }

    public void BackButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        SceneManager.LoadScene(0);
    }

    public void PlayAgainButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        SceneManager.LoadScene(1);
    }
}
