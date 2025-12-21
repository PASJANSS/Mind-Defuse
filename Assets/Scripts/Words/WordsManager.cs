using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordsManager : MonoBehaviour
{
    List<string> words = new List<string> { "kobiety", "jednostka", "grzmot", "rzecz", "strumieñ", "szalik", "rytm", "obsada", "zmiana", "broda", "zawody", "drzwi", 
        "szk³o", "meduza", "wiedza", "metal", 
        "pokwitowanie", "yam", "kraj", "si³a", "¿aby", "zagadka", "stó³" };
    List<string> neededWords = new List<string>();

    public List<TextMeshProUGUI> buttons = new List<TextMeshProUGUI>();
    int correctButton;
    string myWord;
    int correctAnswerCounter;
    public Renderer lamp;
    bool isDone;
    public Image fillBar;
    int lastLives;

    List<string> ReinitializeList()
    {
        return new List<string> { "kobiety", "jednostka", "grzmot", "rzecz", "strumieñ", "szalik", "rytm", "obsada", "zmiana", "broda", "zawody", "drzwi", "szk³o",
            "meduza", "wiedza", "metal",
        "pokwitowanie", "yam", "kraj", "si³a", "¿aby", "zagadka", "stó³" };
    }

    private void Start()
    {
        lastLives = BombIDGen.Instance.lives;
        if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives == 0) neededWords = new List<string> { "kobiety", "jednostka", "grzmot", "rzecz", "strumieñ", "szalik", "rytm", "obsada" };
        if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives == 1) neededWords = new List<string> { "zmiana", "broda", "zawody", "drzwi", "szk³o", "meduza", "wiedza" };
        if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives >= 2) neededWords = new List<string> { "metal", "pokwitowanie", "yam", "kraj", "si³a", "¿aby", "zagadka", "stó³" };

        for (int i = 0; i < neededWords.Count; i++)
        {
            if (words.Contains(neededWords[i]))
            {
                words.Remove(neededWords[i]);
            }
        }
        CreateCombination();
    }

    private void Update()
    {
        if (BombIDGen.Instance.lives != lastLives)
        {
            lastLives = BombIDGen.Instance.lives;
            words = ReinitializeList();
            if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives == 0) neededWords = new List<string> { "kobiety", "jednostka", "grzmot", "rzecz", "strumieñ", "szalik", "rytm", "obsada" };
            if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives == 1) neededWords = new List<string> { "zmiana", "broda", "zawody", "drzwi", "szk³o", "meduza", "wiedza" };
            if (BombIDGen.Instance.startLives - BombIDGen.Instance.lives >= 2) neededWords = new List<string> { "metal", "pokwitowanie", "yam", "kraj", "si³a", "¿aby", "zagadka", "stó³" };

            for (int i = 0; i < neededWords.Count; i++)
            {
                if (words.Contains(neededWords[i]))
                {
                    words.Remove(neededWords[i]);
                }
            }
            CreateCombination();
        }
    }

    void CreateCombination()
    {
        int a = Random.Range(0, neededWords.Count);
        myWord = neededWords[a];

        for (int i = 0; i < 4; i++)
        {
            int v = Random.Range(0, words.Count);
            buttons[i].text = words[v];
        }
        correctButton = Random.Range(0, 4);
        buttons[correctButton].text = myWord;
    }

    public void ButtonClicked(int buttonIndex)
    {
        if (isDone) return;
        if(buttonIndex == correctButton)
        {
            correctAnswerCounter++;
            if (correctAnswerCounter >= 3)
            {
                BombIDGen.Instance.WinLamp(lamp);
                BombIDGen.Instance.gamesDone++;
                isDone = true;
            }
            else
            {
                BombIDGen.Instance.LightLamp(lamp, 1);
                CreateCombination();
            }
        }
        else
        {
            correctAnswerCounter = 0;
            BombIDGen.Instance.LightLamp(lamp, 0);
            BombIDGen.Instance.lives--;
            CreateCombination();
        }
        fillBar.fillAmount = 0.33f * correctAnswerCounter;
    }
}
