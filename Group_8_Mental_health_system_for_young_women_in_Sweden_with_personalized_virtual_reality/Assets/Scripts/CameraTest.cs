using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraTest : MonoBehaviour
{
    readonly private float sensitivity = 25.0f;
    readonly private float clampAngle = 90.0f;
 
    private float angleX; 
    private float angleY; 

    // Start is called before the first frame update
    void Start()
    {
      
        Vector3 angle = transform.localRotation.eulerAngles;
        angleX = angle.x;
        angleY = angle.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
 
        angleX += mouseY * sensitivity * Time.deltaTime;
        angleY += mouseX * sensitivity * Time.deltaTime;
 
        angleX = Mathf.Clamp(angleX, -clampAngle, clampAngle);
 
        Quaternion localRotation = Quaternion.Euler(angleX, angleY, 0.0f);
        transform.rotation = localRotation;
    }
}
