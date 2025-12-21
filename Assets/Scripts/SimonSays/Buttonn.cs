using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonn : MonoBehaviour
{
    public SimonSays man;
    public int index;

    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        man.ButtonClicked(index);
        GetComponent<Animator>().SetTrigger("click");
    }
}
