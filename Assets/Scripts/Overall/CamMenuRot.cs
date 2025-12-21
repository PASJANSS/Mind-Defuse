using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMenuRot : MonoBehaviour
{
    public float rotSpeed = 0.1f;
    float yRot;

    private void Start()
    {
        yRot = transform.rotation.y;
    }

    private void Update()
    {
        yRot += rotSpeed;
        transform.rotation = Quaternion.Euler(transform.rotation.x, yRot, transform.rotation.z);
    }
}
