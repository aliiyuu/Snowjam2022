using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Dictionary<string, int> inv = new Dictionary<string, int>();

    [SerializeField]
    private int test;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            Interactable obj = collision.GetComponent<Interactable>();
            obj.interact(this);
        }
    }

    public void addItem(string item)
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


