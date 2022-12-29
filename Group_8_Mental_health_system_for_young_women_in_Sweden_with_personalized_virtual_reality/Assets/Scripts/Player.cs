using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    readonly private float VELOCITY = 15f;
    readonly private float JUMPFORCE = 120f;
    
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        //CONTROLS
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JUMPFORCE);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * VELOCITY);
        }

        if(Input.GetKey(KeyCode.S)){

            rb.AddForce(Vector3.back * VELOCITY);
        }

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * VELOCITY);
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * VELOCITY);
        }
        /////////////////////////////////////////
    }
}
