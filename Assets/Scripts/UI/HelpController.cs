using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpController : MonoBehaviour
{
    int page = 0;
    public string[] texts;
    public Sprite[] sprites;
    public Image helpImage;
    public TextMeshProUGUI label;
    public TextMeshProUGUI pageText;
    public int pages;
    public GameObject menu;
    public TextMeshProUGUI backLabel;

    private void Start()
    {
        label.text = texts[page];
        helpImage.sprite = sprites[page];
    }

    public void BackButtonClicked()
    {
        MenuSoundManager.Instance.PlayClickSfx();
        backLabel.fontStyle = FontStyles.Normal;
        menu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void NextPageButtonClicked()
    {
        if (page >= pages - 1) return;
        MenuSoundManager.Instance.PlayNextPageSfx();
        page++;
        label.text = texts[page];
        helpImage.sprite = sprites[page];
        pageText.text = page + 1 + "/" + pages;
    }

    public void PreviousPageButtonClicked()
    {
        if (page <= 0) return;
        MenuSoundManager.Instance.PlayPreviousPageSfx();
        page--;
        label.text = texts[page];
        helpImage.sprite = sprites[page];
        pageText.text = page + 1 + "/" + pages;
    }
}
