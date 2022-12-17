using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    string itemName;

    //defaults to picking up
    public void interact(PlayerInteract playerInteract)//GameObject player)
    {
        //PlayerInteract playerInteract = player.GetComponent<PlayerInteract>();
        playerInteract.addItem(itemName);
        Destroy(gameObject); //remove self from world
    }

    public void test()
    {
        Debug.Log("A");
    }
}
