using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharOrderManager : MonoBehaviour
{
    public GameObject[] buttons;
    public Image[] buttonLabels;
    public Sprite[] order1;
    public Sprite[] order2;
    public Sprite[] order3;
    public Sprite[] order4;
    public MeshRenderer lamp;
    int index;
    int buttonsClicked;
    int nextIndex;
    List<int> randomizedChars = new List<int>();
    Sprite[] myArray;
    int val;
    bool areNums;
    bool isDone;
    private void Start()
    {
        for (int i = 0; i < BombIDGen.Instance.id.Length; i++)
        {
            if(i == 0)
            {
                if (char.IsNumber(BombIDGen.Instance.id[i])) areNums = true;
            }
            else if (i == BombIDGen.Instance.id.Length - 1)
            {
                if (!char.IsNumber(BombIDGen.Instance.id[i])) areNums = false;
            }
        }
        if (areNums) val++;
        if (BombIDGen.Instance.batteriesCombination == 0) val += 50;
        else val += 30;
        if (val == 50) { myArray = order2;}
        else if (val == 30) { myArray = order3;}
        else if (val == 1) { myArray = order1;}
        else { myArray = order4;}

        for (int i = 0; i < buttons.Length; i++)
        {
            int x = Random.Range(0, myArray.Length);
            do { x = Random.Range(0, myArray.Length); } while (randomizedChars.Contains(x));
            buttons[i].GetComponent<CharButton>().myChar = myArray[x];
            buttons[i].GetComponent<CharButton>().myCharIndex = x;
            buttonLabels[i].sprite = myArray[x];
            randomizedChars.Add(x);
        }
        for (int i = 0; i < myArray.Length; i++)
        {
            if (randomizedChars.Contains(i) && i > index)
            {
                nextIndex = i; break;
            }
        }
    }

    public void ButtonClick(int myCharIndex)
    {
        if (isDone) return;
        if (myCharIndex != nextIndex)
        {
            BombIDGen.Instance.LightLamp(lamp, 0);
            BombIDGen.Instance.lives--;
            index = 0;
            buttonsClicked = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (randomizedChars.Contains(i)) 
                { 
                    nextIndex = i; break; 
                }
            }
        }
        else
        {
            BombIDGen.Instance.LightLamp(lamp, 1);
            buttonsClicked++;
            index = myCharIndex;
            if (buttonsClicked >= 9)
            {
                BombIDGen.Instance.gamesDone++;
                BombIDGen.Instance.WinLamp(lamp);
                isDone = true;
            }
            for (int i = 0; i < myArray.Length; i++)
            {
                if (randomizedChars.Contains(i) && i > index)
                {
                    nextIndex = i; break;
                }
            }
        }
    }
}
