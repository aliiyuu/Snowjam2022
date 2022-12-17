using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Dictionary<string, int> inv = new Dictionary<string, int>();
    //private List<Interactable> interactList = new List<Interactable>();
    private Interactable lastInteract;
    //private string lastInteractName; useless, unless pick up items are overlapping for some reason

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

}


