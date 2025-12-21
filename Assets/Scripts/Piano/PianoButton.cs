using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoButton : MonoBehaviour
{
    public Piano man;
    public int id;

    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        GetComponent<Animator>().SetTrigger("click");
        man.ButtonClicked(id);
    }
}
