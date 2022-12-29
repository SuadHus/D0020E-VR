using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubTeleporter : MonoBehaviour
{
    readonly private int HUBDELAY = 2;

    void Start()
    {
        GameManager.instance.sceneFinished += StartBackToHubCooldown;
    }

    void Update()
    {
        
    }
    
    private void StartBackToHubCooldown()
    {
        Invoke("TeleportToHub", HUBDELAY); 
    }

    private void TeleportToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}
