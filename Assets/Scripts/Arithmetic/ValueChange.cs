using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueChange : MonoBehaviour
{
    public int valueIncrease;
    public ApplyButton man;

    private void OnMouseDown()
    {
        SoundManager.Instance.PlayButtonSfx();
        man.value += valueIncrease;
        man.text.text = man.value.ToString();
        GetComponent<Animator>().SetTrigger("click");
    }
}
