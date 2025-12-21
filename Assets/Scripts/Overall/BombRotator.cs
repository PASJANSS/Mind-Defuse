using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRotator : MonoBehaviour
{
    public float sensivity;
    bool isMouseDown;
    float fov = 60;
    public float closerLookSpeed = 2;
    float rotX;
    float rotY;
    public float distance = 3;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) isMouseDown = true;
        else if (Input.GetMouseButtonUp(1)) isMouseDown = false;

        if(isMouseDown)
        {
            Debug.Log("mouse donw");
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");
            rotX += mouseX;
            rotY += mouseY;
            Camera.main.transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
            Camera.main.transform.position = transform.position - Camera.main.transform.forward * distance;
        }
        if(fov < 130 || Input.GetAxis("Mouse ScrollWheel") > 0)
            fov -= Input.GetAxis("Mouse ScrollWheel") * closerLookSpeed;
        Camera.main.fieldOfView = fov;
        Debug.Log(fov);
    }
}
