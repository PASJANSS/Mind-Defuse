using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CesarButton : MonoBehaviour
{
    [HideInInspector] public string word;
    public Cesar man;

    private void OnMouseDown()
    {
        man.ButtonClicked(word);
        GetComponent<Animator>().SetTrigger("click");
    }
}
