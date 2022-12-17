using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Dictionary<string, int> inv = new Dictionary<string, int>();
    //private List<Interactable> interactList = new List<Interactable>(); //if this is needed, attatch a script to the objects that inform the player of ontriggerleave() so you can remove the right one?
    private Interactable lastInteract;
    //private string lastInteractName; useless, unless pick up items are overlapping for some reason



    private int heatLevel;

    [SerializeField]
    int heatDegradeTime;

    // Start is called before the first frame update
    void Start()
    {
        heatLevel = 0; //maybe change
        inv["torch"] = 0;
        inv["wood"] = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(heatLevel);
        if(Input.GetKeyDown(KeyCode.E) && lastInteract != null)// && interactList.Count > 0)
        {
            lastInteract.Interact(this);
            //interactList[0].Interact(this);
            //interactList.RemoveAt(0);
        }

        //torch
        if(Input.GetKeyDown(KeyCode.Q) && inv["torch"] > 0)
        {
            UseTorch();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            lastInteract = collision.GetComponent<Interactable>();
            Debug.Log(lastInteract.GetName());
            //lastInteractName = lastInteract.GetName();
            //interactList.Insert(0, obj);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            lastInteract = null;
        }
    }



    public void AddItem(string item)
    {
        try
        {
            inv[item] += 1;
        }
        catch
        {
            inv[item] = 1;
        }
        Debug.Log(inv[item]);
    }

    public void RemoveItem(string item)
    {
        try
        {
            if(inv[item] > 0)
            {
                inv[item] -= 1;
            }
        }
        catch
        {
            return;
        }
    }

    public int GetItem(string item)
    {
        try
        {
            return inv[item];
        }
        catch
        {
            return 0;
        }

    }

    private void UseTorch()
    {
        inv["torch"] -= 1;
        Debug.Log("torch moment");
    }

    public int GetHeat()
    {
        return heatLevel;
    }

    public void ChangeHeat(int heatToAdd)
    {
        heatLevel += heatToAdd;
    }
}


