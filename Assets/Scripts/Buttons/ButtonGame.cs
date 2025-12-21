using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonGame : MonoBehaviour
{
    public Color[] buttonColors;
    public string[] buttonTexts;
    public Color[] barColors;
    string[] words = { "eksterminacja", "³apa", "klub", "nocny", "¿ebraæ", "badacz", "g³oœnik", "na", "dole", "szybszy", "egoista", "odbijanie", "tryplet", "sk³adnik",
        "kot", "niekompatybilny", "spieraæ", "siê", "³ój", "fleury", "myto", "penologia", "abseil", "nadbudowa", "nieve", "selektywnoœæ", "fa³szowanie", "spektroskop",
        "kordon", "afirmowaæ", "elektryfikowaæ", "ksiê¿yc", "od³¹cza", "d³awiæ", "siê", "wypêdzaæ", "zaserwowaæ", "zagalopowaæ", "w¿ywaæ", "podowiadywaæ", "diploidalny",
        "emfatyczny", "hieroglificzny", "niegotowy", "niemi³y", "obcopylny", "obraŸliwy", "odludny", "przegrodowy", "uproszczone", "wê¿ykowaty", "suchotniczy",
        "rozprê¿ny", "rozbie¿ny" };
    List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', '¹', 'ê', 'ó' };

    public Renderer bar;
    public Renderer lamp;
    public Renderer button;
    public TextMeshProUGUI buttonText;

    int randomizedButtonColor;
    string randomizedButtonText;

    Color startBarColor;
    bool isGoingDown;
    bool isGoingUp;
    const float upZPos = 0;
    const float downZPos = .23f;
    float pos;
    public float animationSpeed = 0.02f;
    float timeFromClick;
    int timerStopSec = 1000;
    int timerStopAll = 1000;
    bool isTimeGoingDown;
    int vowelsInWord;
    int clickCounter;
    bool isDone;
    string all;
    string sec;
    int correctAnswer; //0 - click, 1 - double click, 2 - hold.
    private void Start()
    {
        /*| Colors |
          V        V
         0 - red
         1 - blue
         2 - green
         3 - purple
         */
        startBarColor = bar.material.color;
        int a = Random.Range(0, buttonColors.Length);
        randomizedButtonColor = a;
        int b = Random.Range(0, buttonTexts.Length);
        randomizedButtonText = buttonTexts[b];
        button.material.color = buttonColors[a];
        buttonText.text = randomizedButtonText;

        if (a == b) correctAnswer = 0;
        else if (b - a == -1 || (b == 3 && a == 0)) correctAnswer = 1;
        else correctAnswer = 2;
    }
    //red, blue, green, purple
    private void Update()
    {
        if (isGoingDown)
        {
            pos += animationSpeed;
            if (pos >= downZPos) isGoingDown = false;
            transform.localPosition = new Vector3(0, 0, pos);
        }
        else if (isGoingUp)
        {
            pos -= animationSpeed;
            if (pos <= upZPos) isGoingUp = false;
            transform.localPosition = new Vector3(0, 0, pos);
        }
        if (isTimeGoingDown)
            timeFromClick += Time.deltaTime;
    }

    void GenerateBarColor()
    {
        int barType = Random.Range(0, 3);
        if (barType == 0)
        {
            int color = Random.Range(0, barColors.Length);
            bar.material.color = barColors[color];
            timerStopAll = color + 1;
        }
        else if (barType == 1)
        {
            int number = Random.Range(100, 200);
            TextMeshProUGUI barLabel = bar.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // child 0 index = bar text;
            barLabel.gameObject.SetActive(true);
            barLabel.text = number.ToString();

            int sum = 0;
            foreach (char z in number.ToString())
                sum += z - '0';

            if (number % 4 == 0) timerStopSec = 5;
            else if (number % 4 != 0) timerStopSec = 6;
            if (sum % 3 == 0) timerStopSec = 7;
            if (number % 5 == 0) timerStopSec = 8;
        }
        else
        {
            string word = words[Random.Range(0, words.Length)];
            TextMeshProUGUI barLabel = bar.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // child 0 index = bar text;
            barLabel.gameObject.SetActive(true);
            barLabel.text = word;

            if (vowels.Contains(word[0])) timerStopAll = 9;
            else timerStopSec = 0;
            if (!vowels.Contains(word[word.Length - 1]))
            {
                timerStopAll = 1000;
                timerStopSec = 2;
            }

            for (int i = 0; i < word.Length; i++)
                if (vowels.Contains(word[i])) vowelsInWord++;

            if (vowelsInWord > word.Length - vowelsInWord)
            {
                timerStopAll = 1;
                timerStopSec = 1000;
            }
        }
    }

    void CorrectAnswer()
    {
        BombIDGen.Instance.WinLamp(lamp);
        BombIDGen.Instance.gamesDone++;
        isDone = true;
    }

    void WrongAnswer()
    {
        BombIDGen.Instance.LightLamp(lamp, 0);
        BombIDGen.Instance.lives--;
    }

    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        if (isDone) return;
        isGoingDown = true;
        isTimeGoingDown = true;
        if (correctAnswer == 2) GenerateBarColor();
    }

    private void OnMouseUp()
    {
        if (isDone) return;
        clickCounter++;
        isGoingUp = true;
        if (correctAnswer == 2)
        {
            sec = timerStopSec.ToString();
            all = timerStopAll.ToString();
            if (timerStopAll == 1000) all = "a";
            if (timerStopSec == 1000) sec = "a";
            Debug.Log("All: " + timerStopAll + " Last: " + timerStopSec);
            if (BombIDGen.Instance.seconds.Contains(char.Parse(all)) || BombIDGen.Instance.minutes.Contains(char.Parse(all)))
                CorrectAnswer();
            else if (BombIDGen.Instance.seconds[1] == char.Parse(sec.ToString()))
                CorrectAnswer();
            else
                WrongAnswer();
            isTimeGoingDown = false;
            timeFromClick = 0;
        }
        else if (correctAnswer == 0)
        {
            if (timeFromClick < 1)
                CorrectAnswer();
            else
                WrongAnswer();
            isTimeGoingDown = false;
            timeFromClick = 0;
        }
        else if (clickCounter == 2)
        {
            if (timeFromClick < 1)
                CorrectAnswer();
            else
                WrongAnswer();
            timeFromClick = 0;
            clickCounter = 0;
            isTimeGoingDown = false;
        }
        bar.material.color = startBarColor;
        bar.transform.GetChild(0).gameObject.SetActive(false);

    }
}

