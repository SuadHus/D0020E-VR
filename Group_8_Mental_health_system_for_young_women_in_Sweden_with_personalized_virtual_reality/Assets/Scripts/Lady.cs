using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Lady : MonoBehaviour
{
    //Variables used to figure out distance from player to lady
    readonly private int CLOSETOLADYRADIUS = 3;
    private bool closeToLady;
    Vector3 PlayerPos;
    Vector3 LadyPos;

    //The narrative
    string[] firstDialogueLines = new string[]{
    "Hello!", 
    "Could you please help me save my cat? He is stuck in a tree.", 
    "To get him down we will need a ladder.", 
    "But first we need to collect some planks.", 
    "Come back to me when you have found them.",
    "Good luck!"};

    //Keeping track of the state of the first dialogue
    int FirstLadyDialogueLength;
    int firstDialogueIteration;
    
    //The ladys text variables
    public TMP_Text interactionText;
    public TMP_Text helpText;

    void Start()
    {
        //Sets state variables of the first dialogue
        firstDialogueIteration = 0;
        FirstLadyDialogueLength = firstDialogueLines.Length;

        //Enable/Disable text
        interactionText.enabled = false;
        helpText.enabled = true;

        //Subrcribing to ladyLineFinished 
        GameManager.instance.ladyLineFinished += StartLadyDialogueCoroutine;

        //Starting the first lady dialogue
        StartLadyDialogueCoroutine();
    }

    //Checks if the player is within the "CLOSETOLADYRADIUS"
    void Update()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        LadyPos = GameObject.FindGameObjectWithTag("Lady").transform.position;

        if(Mathf.Abs(PlayerPos.x - LadyPos.x) < CLOSETOLADYRADIUS && Mathf.Abs(PlayerPos.z - LadyPos.z) < CLOSETOLADYRADIUS)
        {
            closeToLady = true;
            helpText.color = new Color(255, 255, 0, 50);
            helpText.text = "Press F to interact or continue dialogue with lady";
        }
        else
        {
            closeToLady = false;
            helpText.color = new Color(255, 0, 0, 50);
            helpText.text = "Walk closer to interact with lady";
        }
    }

    //Starts the first dialogue with the lady
    void StartLadyDialogueCoroutine()
    {
        StartCoroutine(FirstLadyDialogue());
    }

    //Used to busy wait while interacting with the lady, called by GameManager after first call.
    private IEnumerator FirstLadyDialogue()
    {
        //Waits for the player to be close to the lady and for F to be pressed
        while (!Input.GetKeyDown(KeyCode.F) || closeToLady == false)
        {
            yield return null;
        }

        //Adjusting variables
        interactionText.enabled = true;
        interactionText.text = firstDialogueLines[firstDialogueIteration];
        firstDialogueIteration = firstDialogueIteration + 1;
        
        //Checks if the dialogue is finished or not
        if(this.firstDialogueIteration < FirstLadyDialogueLength)
        {
            Invoke("NotifyGameManager", 0.2f);
        }
        else
        {
            IterationFinished();
        }
    }

    //Called after each whole iteration with the lady
    private void IterationFinished()
    {
        helpText.enabled = false;
        GameManager.instance.TalkedToLady();
    }
    
    //Tells the GameManager that we want to continue our conversation with the lady
    private void NotifyGameManager()
    {
        GameManager.instance.NextLineLady();
    }
}
