using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillButton : MonoBehaviour
{
    public Killing man;
    public bool isKilling;

    private void OnMouseDown()
    {
        if (!isKilling)
        {
            SoundManager.Instance.PlayButtonSfx();
            GetComponent<Animator>().SetTrigger("click");
            if (man.start)
                man.Kill(false);
            else
            {
                man.start = true;
                man.GenerateGuy();
            }
        }
        else
        {
            if(man.start)
                man.Kill(true);
            else
            {
                man.start = true;
                man.GenerateGuy();
            }
        }
    }
}
