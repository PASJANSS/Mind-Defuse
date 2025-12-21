using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableController : MonoBehaviour
{
    public CutManager man;
    public int id;
    public ParticleSystem correct;
    public ParticleSystem incorrect;
    public Texture2D cursor;


    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        man.CableCllicked(id, gameObject, correct, incorrect);
    }
}
