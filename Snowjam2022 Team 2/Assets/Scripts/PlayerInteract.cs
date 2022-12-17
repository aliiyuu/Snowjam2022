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

    // Start is called before the first frame update
    void Start()
    {
        heatLevel = 0; //maybe change
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


    public int GetHeat()
    {
        return heatLevel;
    }

    public void ChangeHeat(int heatToAdd)
    {
        heatLevel += heatToAdd;
    }
}


