using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSpawner : MonoBehaviour
{
    public GameObject plank;
    bool hasSpawned;  //boolean used so that the planks only spawn once

    void Start()
    {
        hasSpawned = false;
        GameManager.instance.ladyInteraction += SpawnPlanks;
    }

    void Update()
    {
        
    }

    private void SpawnPlanks()
    {
        if(hasSpawned == false)
        {
            Instantiate(plank, new Vector3(3, 0, 0), Quaternion.identity);
            Instantiate(plank, new Vector3(-2, 0, -2), Quaternion.identity);
            Instantiate(plank, new Vector3(4, 0, 5), Quaternion.identity);
            Instantiate(plank, new Vector3(-0, 0, 2), Quaternion.identity);
        }
        hasSpawned = true;
    }
}
