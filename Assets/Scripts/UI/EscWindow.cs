using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EscWindow : MonoBehaviour
{
    public GameObject bomb;
    public List<TextMeshProUGUI> buttons = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> labels = new List<TextMeshProUGUI>();
    public void MenuButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        Camera.main.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        SoundManager.Instance.PlayExplosionSfx();
        Destroy(bomb);
        foreach (var label in labels) label.enabled = false;
        transform.parent.GetComponent<Image>().enabled = false;
        Invoke("LoadScene", 1.5f);
    }

    private void OnEnable()
    {
        foreach (var button in buttons) button.fontStyle = FontStyles.Normal;
    }

    public void ResumeButtonClicked()
    {
        transform.parent.gameObject.SetActive(false);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}