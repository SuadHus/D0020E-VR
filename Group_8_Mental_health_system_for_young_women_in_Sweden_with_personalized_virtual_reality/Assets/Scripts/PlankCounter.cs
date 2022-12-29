using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCounter : MonoBehaviour
{
    public static PlankCounter instance;

    readonly private int TOTALPLANKS = 4;
    private int planksPickedUp;

    void Start()
    {
        instance = this;
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

    public int GetPlanksPickedUp()
    {
        return planksPickedUp;
    }
    
    public int GetTotalPlanks()
    {
        return TOTALPLANKS;
    }
}
