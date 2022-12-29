using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EventHUD : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text eventText;

    void Start()
    {
        
        eventText.enabled = false;
        
        GameManager.instance.gameStarted += SetGameStartedText;
        GameManager.instance.ladyInteraction += SetLadyInteractionText;
        GameManager.instance.plankPickedUp += SetPlankPickedUpText;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetGameStartedText()
    {
        checkActive();
        eventText.text = "Game Started!";
        ActivateText();
    }

    private void SetLadyInteractionText()
    {
        checkActive();
        eventText.text = "Interacted with lady";
        ActivateText();
    }

    private void SetPlankPickedUpText()
    {
        checkActive();
        eventText.text = "Picked up plank";
        ActivateText();
    }

    //General functions
    private void checkActive()
    {
        if(eventText.enabled == true)
        {
            CancelInvoke("DeactivateText");
        }
    }

    private void ActivateText()
    {
        eventText.enabled = true;
        Invoke("DeactivateText", 3);
    }

    private void DeactivateText()
    {
        eventText.enabled = false;   
    }
}
