using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    readonly private float JUMPFORCE = 120f;
    readonly private float SPEED = 240;
    
    readonly private float sensitivity = 140.0f;
    readonly private float clampAngle = 90.0f;
 
    private float angleX; 
    private float angleY; 

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Vector3 angle = transform.localRotation.eulerAngles;
        angleX = angle.x;
        angleY = angle.y;
        
    }

    void Update()
    {
        //MOVEMENT
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JUMPFORCE);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * SPEED * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S)){

            rb.velocity = -transform.forward * SPEED * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * SPEED * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * SPEED * Time.deltaTime;
        }

        //LOOK
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
 
        angleX += mouseY * sensitivity * Time.deltaTime;
        angleY += mouseX * sensitivity * Time.deltaTime;
 
        angleX = Mathf.Clamp(angleX, -clampAngle, clampAngle);
 
        Quaternion localRotation = Quaternion.Euler(angleX, angleY, 0.0f);
        transform.rotation = localRotation;
    }
}
