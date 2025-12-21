using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuSoundManager.Instance.PlayHoverSfx();
        //transform.GetChild(0).gameObject.SetActive(true);
        try
        {
            transform.parent.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
        }
        catch
        {
            GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MenuSoundManager.Instance.PlayHoverSfx();
        //transform.GetChild(0).gameObject.SetActive(false);
        try
        {
            transform.parent.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        }
        catch
        {
            GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        }
    }
}
