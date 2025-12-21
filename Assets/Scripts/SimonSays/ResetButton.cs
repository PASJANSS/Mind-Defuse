using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public SimonSays man;

    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        GetComponent<Animator>().SetTrigger("click");
        StartCoroutine(man.ShowSequence(man.wantedClicks));
    }
}
