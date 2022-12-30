using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Lady : MonoBehaviour
{
    int[] array = new int[]{1, 2, 3, 4, 5};
    int dialogueIteration = 0;

    Rigidbody rb;

    public TMP_Text interactionText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        interactionText.enabled = false;
        GameManager.instance.ladyInteraction += StartLadyDialogueCoroutine;
        //StartLadyDialogueCoroutine();
       // GameManager.instance.ladyMeetDialogue += StartLadyDialogueCoroutine;
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

    void StartLadyDialogueCoroutine()
    {
        StartCoroutine(FirstLadyDialogue(dialogueIteration));
    }

    private IEnumerator FirstLadyDialogue(int dialogueIteration)
    {
        print("början");
        //interactionText.text = "Hello! \n \n (press F to continue)";
        interactionText.text = array[dialogueIteration].ToString();
        interactionText.enabled = true;

        while (!Input.GetKeyDown(KeyCode.F))
        {
            yield return null;
        }

        interactionText.enabled = false;
        this.dialogueIteration = this.dialogueIteration + 1;
        print(this.dialogueIteration);
        /*
        if(this.dialogueIteration < 5)
        {
            GameManager.instance.NextLineLady();
        }*/
    }   
}
