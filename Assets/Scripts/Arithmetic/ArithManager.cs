using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArithManager : MonoBehaviour
{
    public TextMeshProUGUI questionLabel;
    public Renderer lamp;
    List<int> nums = new List<int>();
    List<string> operators = new List<string>();
    string[] possibleOperators = {"+", "-", "*", "/"};
    int score;
    int addingValue = 0;
    int decreasingValue = 0;
    int parzyste;
    int checkedConditions;

    private void Start()
    {
        if (BombIDGen.Instance.cableColor == 2)
        {
            Debug.Log("1");
            checkedConditions++;
            for (int i = 0; i < BombIDGen.Instance.id.Length; i++)
            {
                if (char.IsNumber(BombIDGen.Instance.id[i]))
                {
                    addingValue = BombIDGen.Instance.id[i] - '0';
                    break;
                }
            }
        }
        int times = Random.Range(2, 4);
        for(int i = 0; i < times; i++)
        {
            int w = Random.Range(0, 7);
            nums.Add(w + addingValue - decreasingValue);
            if (w % 2 == 0) parzyste++;
            if (i < times - 1) operators.Add(possibleOperators[Random.Range(0, 4)]);
            else operators.Add("");
            questionLabel.text += w.ToString() + operators[i];
        }

        if (BombIDGen.Instance.batteriesCombination == 1 && operators.Contains("+")) { decreasingValue = 1; checkedConditions++; Debug.Log("2"); }

        if (parzyste >= 2 && BombIDGen.Instance.cableColor == 0)
        {
            Debug.Log("3");
            checkedConditions++;
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == "+") operators[i] = "-";
                else if (operators[i] == "-") operators[i] = "+";
                else if (operators[i] == "*") operators[i] = "/";
                else operators[i] = "*";
            }
        }

        if(BombIDGen.Instance.cutCable == 1)
        {
            Debug.Log("4");
            checkedConditions++;
            int pom = nums[0];
            nums[0] = nums[1];
            nums[1] = pom;
        }

        if(checkedConditions != 1)
        {
            Debug.Log("5");
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == "+") operators[i] = "-";
                else if (operators[i] == "-") operators[i] = "+";
                else if (operators[i] == "*") operators[i] = "/";
                else operators[i] = "*";
            }
        }

        if(operators.Count != 2)
        {
            if (operators[0] == "*")
            {
                if (operators[1] == "+") score = nums[0] * nums[1] + nums[2];
                if (operators[1] == "-") score = nums[0] * nums[1] - nums[2];
                if (operators[1] == "/")
                {
                    if (nums[2] != 0)
                        score = nums[0] * nums[1] / nums[2];
                    else score = 0;
                }
                if (operators[1] == "*") score = nums[0] * nums[1] * nums[2];
            }
            else if (operators[0] == "/")
            {
                if (nums[1] != 0)
                {
                    if (operators[1] == "+") score = nums[0] / nums[1] + nums[2];
                    if (operators[1] == "-") score = nums[0] / nums[1] - nums[2];
                    if (operators[1] == "/")
                    {
                        if (nums[2] != 0)
                            score = nums[0] / nums[1] / nums[2];
                        else score = 0;
                    }
                    if (operators[1] == "*") score = nums[0] / nums[1] * nums[2];
                }
            }
            else if (operators[0] == "+")
            {
                if (operators[1] == "+") score = nums[0] + nums[1] + nums[2];
                if (operators[1] == "-") score = nums[0] + nums[1] - nums[2];
                if (operators[1] == "/")
                {
                    if (nums[2] != 0)
                        score = nums[0] + nums[1] / nums[2];
                    else score = 0;
                }
                if (operators[1] == "*") score = nums[0] + nums[1] * nums[2];
            }
            else
            {
                if (operators[1] == "+") score = nums[0] - nums[1] + nums[2];
                if (operators[1] == "-") score = nums[0] - nums[1] - nums[2];
                if (operators[1] == "/")
                {
                    if (nums[2] != 0)
                        score = nums[0] - nums[1] / nums[2];
                    else score = 0;
                }
                if (operators[1] == "*") score = nums[0] - nums[1] * nums[2];
            }
        }
        else
        {
            if (operators[0] == "+") score = nums[0] + nums[1];
            if (operators[0] == "-") score = nums[0] - nums[1];
            if (operators[0] == "/")
            {
                if(nums[1] != 0)
                    score = nums[0] / nums[1];
                else score = 0;
            }
            if (operators[0] == "*") score = nums[0] * nums[1];
        }
    }

    public void ButtonClicked(int val)
    {
        Debug.Log(val + " " + score);
        if(val == score)
        {
            Debug.Log("mega");
            BombIDGen.Instance.WinLamp(lamp);
            BombIDGen.Instance.gamesDone++;
        }
        else
        {
            BombIDGen.Instance.lives--;
            BombIDGen.Instance.LightLamp(lamp, 0);
        }
    }
}
