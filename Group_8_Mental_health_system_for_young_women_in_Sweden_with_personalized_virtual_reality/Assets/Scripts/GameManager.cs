using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action gameStarted, ladyInteraction, ladyLineFinished, plankPickedUp, sceneFinished;

    private void Awake()
    {
        instance = this;
        Invoke("StartGame", 1); //delay is needed so that other classes have time to react to event
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    //Called when starting game
    public void StartGame()
    {
        Debug.Log("Started game");
        gameStarted?.Invoke();
    }

    //Called when a line has been spoken by lady
    public void NextLineLady()
    {
        Debug.Log("talking to lady");
        ladyLineFinished?.Invoke();
    }

    //Called after a dialogue with the lady
    public void TalkedToLady()
    {
        Debug.Log("lady interaction");
        ladyInteraction?.Invoke(); 
    }

    //Called when a plank is picked up
    public void PlankPickedUp()
    {
        Debug.Log("Picked up plank");
        plankPickedUp?.Invoke();
    }

    //Called when the scene is ending
    public void EndScene()
    {
        Debug.Log("Scene finished");
        sceneFinished?.Invoke();
    }
}
