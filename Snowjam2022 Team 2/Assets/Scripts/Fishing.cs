using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Interactable
{
    private bool catchChance;
    PlayerController playerController;

    public override void Interact(PlayerController playerController)
    {
        if(playerController.GetItem("fishing rod") > -1)
        {
            Debug.Log("starting fish");
            StartCoroutine(StartFish(playerController)); //should move to player controller to lock movement?
        }
    }
    
    private IEnumerator StartFish(PlayerController playerController)
    {
        /*
        if(!PlayerController.IsFishing())
        {
            yield return false;
        }
        */
        yield return new WaitForSeconds(Random.Range(5, 10));
        catchChance = true;
        Debug.Log("FISH TIME");
        playerController.Alert();
        yield return new WaitForSeconds(1);
        catchChance = false;

    }

    private void Update()
    {
        if(catchChance && Input.GetMouseButtonDown(0))
        {
            playerController.AddItem("fish");
            catchChance = false;
        }
    }
}
