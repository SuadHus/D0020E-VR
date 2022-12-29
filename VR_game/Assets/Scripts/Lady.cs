using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lady : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {      
            GameManager.instance.TalkedToLady();
        }
    }
}
//another comment for confict