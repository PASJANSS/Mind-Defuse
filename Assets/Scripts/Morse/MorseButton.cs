using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseButton : MonoBehaviour
{
    public Morse man;
    public bool isApply;
    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        GetComponent<Animator>().SetTrigger("click");
        if (!isApply)
            StartCoroutine(man.ShowLetter(man.scriptedWord, 0));
        else
            man.ApplyButtonClicked();
    }
}
