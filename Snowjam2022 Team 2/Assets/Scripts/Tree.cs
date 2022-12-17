using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactable
{

    float chopTime;
    // Start is called before the first frame update
    void Start()
    {
        chopTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(PlayerController playerController)
    {
        //do nothing
    }
    public override void HoldInteract(PlayerController playerController)
    {
        chopTime += Time.deltaTime; //the player calls this function off of update() so this works
        if(chopTime > playerController.GetChoppingTime())
        {
            playerController.AddItem("wood"); //just 1 wood per tree?
            Destroy(gameObject);
        }
    }
}
