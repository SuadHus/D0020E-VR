using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    bool notPickedUp;   //boolean used to not count the same stick plank twice due to Destroy() delay

    void Start()
    {
        notPickedUp = true;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.tag == "Player")
        {   
            if(notPickedUp == true){
                Destroy(gameObject, 0.3f);
                GameManager.instance.PlankPickedUp();
            }
            notPickedUp = false;

            
        }
    }
}
