using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    string sequence;
    public int sequenceDifficulty;
    int buttonsClicked = 0;
    [HideInInspector] public int wantedClicks = 1;
    public GameObject[] lights;
    public Renderer lamp;
    public Buttonn[] buttons;
    bool isDone;
    int lastLives;
    private void Start()
    {
        lastLives = BombIDGen.Instance.lives;
        if(BombIDGen.Instance.lives == BombIDGen.Instance.startLives)
        {
            buttons[2].index = 3;
            buttons[3].index = 2;
            buttons[1].index = 0;
            buttons[0].index = 1;
        }
        else
        {
            buttons[3].index = 1;
            buttons[1].index = 3;
            buttons[2].index = 0;
            buttons[0].index = 2;
        }

        foreach (var light in lights) light.SetActive(false);
        for(int i = 0; i < sequenceDifficulty; i++)
        {
            sequence += Random.Range(0, 4).ToString();
        }
        lights[sequence[0] - '0'].SetActive(true);
    }

    private void Update()
    {
        if (lastLives != BombIDGen.Instance.lives)
        {
            lastLives = BombIDGen.Instance.lives;
            if (BombIDGen.Instance.lives == BombIDGen.Instance.startLives)
            {
                buttons[2].index = 3;
                buttons[3].index = 2;
                buttons[1].index = 0;
                buttons[0].index = 1;
            }
            else
            {
                buttons[3].index = 1;
                buttons[1].index = 3;
                buttons[2].index = 0;
                buttons[0].index = 2;
            }

            foreach (var light in lights) light.SetActive(false);
            for (int i = 0; i < sequenceDifficulty; i++)
            {
                sequence += Random.Range(0, 4).ToString();
            }
            lights[sequence[0] - '0'].SetActive(true);
            wantedClicks = 1;
            buttonsClicked = 0;
        }
    }

    public void ButtonClicked(int index)
    {
        if (isDone) return;
        foreach (var light in lights) light.SetActive(false);
        if (index == sequence[buttonsClicked] - '0')
        {
            buttonsClicked++;
            if(buttonsClicked >= sequenceDifficulty)
            {
                BombIDGen.Instance.WinLamp(lamp);
                BombIDGen.Instance.gamesDone++;
                isDone = true;
            }
            else if (buttonsClicked >= wantedClicks)
            {
                wantedClicks = buttonsClicked + 1;
                StartCoroutine(ShowSequence(wantedClicks));
                buttonsClicked = 0;
            }
            BombIDGen.Instance.LightLamp(lamp, 1);
        }
        else
        {
            buttonsClicked = 0;
            wantedClicks = 1;
            BombIDGen.Instance.lives--;
            BombIDGen.Instance.LightLamp(lamp, 0);
            lights[sequence[0] - '0'].SetActive(true);
        }

    }

    public IEnumerator ShowSequence(int times)
    {
        foreach (var light in lights) light.SetActive(false);
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(0.3f);
            lights[sequence[i] - '0'].SetActive(true);
            yield return new WaitForSeconds(.3f);
            lights[sequence[i] - '0'].SetActive(false);
        }
    }
}
