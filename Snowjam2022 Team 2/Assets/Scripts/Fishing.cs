using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Interactable
{
    private bool catchChance;
    PlayerController playerController;

    public override void Interact(PlayerController playerController)
    {
        if(playerController.GetItem("Fishing Rod") > 0)
        {
            Debug.Log("starting fish");
            playerController.Fish(); 
        }
    }
}
