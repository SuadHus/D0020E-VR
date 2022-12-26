using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCounter : MonoBehaviour
{
    readonly private int TOTALPLANKS = 4;
    int planksPickedUp;

    void Start()
    {
        planksPickedUp = 0;
        GameManager.instance.plankPickedUp += IncrementPlankScore;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void IncrementPlankScore()
    {
        planksPickedUp += 1;
        checkScenarioFinished();
    }
    private void checkScenarioFinished()
    {
        if(planksPickedUp >= TOTALPLANKS)
        {
            GameManager.instance.EndScene();
        }
    }
}
