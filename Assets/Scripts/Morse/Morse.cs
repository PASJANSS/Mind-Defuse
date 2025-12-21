using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Morse : MonoBehaviour
{
    public string[] words;
    string word;
    string[] letters = { "01", "0101", "1000", "1010", "100", "0", "0010", "110", "0000", "00", "0111", "101", "0100", "11", "10", "111", "0110", "1101", "010", "000",
        "1", "001", "0001", "011", "1001", "1011", "1100" };
    [HideInInspector] public string scriptedWord;
    public GameObject miniLamp;
    public Renderer lamp;
    const float shortBrake = .3f;
    const float longBrake = 1f;
    const float letterBrake = 2f;
    const float miniLetterBrake = .8f;
    public string code;
    public Slider slider;
    string correctAnswer;
    bool isDone;
    int clicked;
    public TextMeshProUGUI label;
    public Color lampLightColor;
    Color defLightColor;

    private void Start()
    {
        miniLamp.SetActive(false);
        defLightColor = BombIDGen.Instance.defLampMat;
        word = words[Random.Range(0, words.Length)];
        foreach (char z in word)
        {
            scriptedWord += letters[(int)z - 97] + " ";
            correctAnswer += (((int)z - 97) / 2).ToString() + ",";
        }
       // StartCoroutine(ShowLetter(scriptedWord, 0));
    }

    public void OnSliderValueChanged()
    {
        label.text = slider.value.ToString();
    }

    public void ApplyButtonClicked()
    {
        if (isDone) return;
        if (slider.value.ToString() == correctAnswer.Split(',')[clicked].ToString()) BombIDGen.Instance.LightLamp(lamp, 1);
        else 
        {
            BombIDGen.Instance.lives--;
            BombIDGen.Instance.LightLamp(lamp, 0);
        }
        clicked++;
        if (clicked >= correctAnswer.Split(',').Length - 1)
        {
            BombIDGen.Instance.gamesDone++;
            BombIDGen.Instance.WinLamp(lamp);
            isDone = true;
        }
    }

    public IEnumerator ShowLetter(string lWord, int i)
    {
        if (!isDone)
        {
            for (int j = i; j < lWord.Length; j++)
            {
                char z = lWord[j];
                if (z == '0')
                {
                    LightLamp(1);
                    yield return new WaitForSeconds(shortBrake);
                    LightLamp(0);
                    yield return new WaitForSeconds(miniLetterBrake);
                }
                else if (z == '1')
                {
                    LightLamp(1);
                    yield return new WaitForSeconds(longBrake);
                    LightLamp(0);
                    yield return new WaitForSeconds(miniLetterBrake);
                }
                else
                {
                    yield return new WaitForSeconds(letterBrake);
                    i++;
                    StartCoroutine(ShowLetter(lWord, i));
                    break;
                }
                i++;
            }
        }
    }

    void LightLamp(int isLighting)
    {
        miniLamp.SetActive(isLighting == 1);
        miniLamp.transform.parent.GetComponent<Renderer>().material.color = defLightColor;
        if (isLighting == 1)
            miniLamp.transform.parent.GetComponent<Renderer>().material.color = lampLightColor;
    }
}
