using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TaskHUD : MonoBehaviour
{
    public TMP_Text taskText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gameStarted += TalkToLadyTask;
        GameManager.instance.ladyInteraction += CollectPlanksTaskDelay;
        GameManager.instance.plankPickedUp += CollectPlanksTaskDelay;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TalkToLadyTask()
    {
        taskText.text = "Task: Interact with the lady";
    }
    private void CollectPlanksTaskDelay(){
        Invoke("CollectPlanksTask", 0.3f); //Needed so that PlankCounter has time to update first
    }
    private void CollectPlanksTask()
    {
        taskText.text = "Task: Collect planks \n" + PlankCounter.instance.GetPlanksPickedUp().ToString() 
        + "/" + PlankCounter.instance.GetTotalPlanks().ToString();
    }
}
