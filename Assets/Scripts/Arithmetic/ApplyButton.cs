using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplyButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int value;
    public ArithManager man;
    private void OnMouseDown()
    {
        man.ButtonClicked(value);
        GetComponent<Animator>().SetTrigger("click");
        SoundManager.Instance.PlayButtonSfx();
    }
}
