using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canv : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
