using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharButton : MonoBehaviour
{
    public Sprite myChar;
    public int myCharIndex;
    public CharOrderManager manager;
    private void OnMouseDown()
    {
        manager.ButtonClick(myCharIndex);
        GetComponent<Animator>().SetTrigger("click");
    }
}
