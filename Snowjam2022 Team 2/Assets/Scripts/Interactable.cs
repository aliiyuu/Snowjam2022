using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    private string itemName;

    //defaults to picking up
    public virtual void Interact(PlayerInteract playerInteract)//GameObject player)
    {
        //PlayerInteract playerInteract = player.GetComponent<PlayerInteract>();
        playerInteract.AddItem(itemName);
        Destroy(gameObject); //remove self from world
    }

    public string GetName()
    {
        return itemName;
    }
}
