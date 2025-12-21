using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeController : MonoBehaviour
{
    public GameObject escapeWindow;
    public GameObject background;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Change();
    }

    public void Change()
    {
        background.SetActive(!background.active);
        background.transform.GetChild(0).gameObject.SetActive(false);
        escapeWindow.SetActive(background.active);
    }
}
