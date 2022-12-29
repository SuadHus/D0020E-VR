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
            Instantiate(plank, new Vector3(10, 0, 13), Quaternion.identity);
            Instantiate(plank, new Vector3(7, 0, 10), Quaternion.identity);
            Instantiate(plank, new Vector3(8, 0, 15), Quaternion.identity);
            Instantiate(plank, new Vector3(11, 0, 10), Quaternion.identity);
        }
        hasSpawned = true;
    }
}
