using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action gameStarted, ladyInteraction, ladyMeetDialogue, plankPickedUp, sceneFinished;

    private void Awake()
    {
        instance = this;
        Invoke("StartGame", 1); //delay is needed so that other classes have time to react to event
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartGame()
    {
        Debug.Log("Started game");
        gameStarted?.Invoke();
    }

    public void TalkedToLady()
    {
        Debug.Log("lady interaction");
        ladyInteraction?.Invoke(); 
    }

    public void NextLineLady()
    {
        Debug.Log("talking to lady");
        ladyMeetDialogue?.Invoke();
    }

    public void PlankPickedUp()
    {
        Debug.Log("Picked up plank");
        plankPickedUp?.Invoke();
    }

    public void EndScene()
    {
        Debug.Log("Scene finished");
        sceneFinished?.Invoke();
    }
}
