using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Dictionary<string, int> inv = new Dictionary<string, int>(); //inventory


    //private List<Interactable> interactList = new List<Interactable>(); //if this is needed, attatch a script to the objects that inform the player of ontriggerleave() so you can remove the right one?
    private Interactable lastInteract; //tracks what you can interact with (most recent collision with an interactable)
    //private string lastInteractName; useless, unless pick up items are overlapping for some reason


    [SerializeField]
    private int heatLevel; //how warm the player is

    [SerializeField]
    private int choppingTime; //time to chop down a tree

    [SerializeField] //need to see it in editor for testing
    private int health; //health. 
    private int maxHealth;
    [SerializeField] //so you can see freeze levels in editor
    private float freeze; //how frozen the player is.
    private float maxFreeze;

    private GameUI gameUI; // Get sceneUI


    //player movement
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;


// Start is called before the first frame update
void Start()
    {
        health = 100; //who knows, maybe up this
        maxHealth = 100;
        freeze = 0;
        maxFreeze = 100;

        heatLevel = 0; //maybe change
        inv["torch"] = 0; //this one needs to be here 

        //numbers for testing, mostly
        inv["wood"] = 3;

        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        gameUI = GameObject.Find("Canvas").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //Debug.Log(heatLevel);
        if (Input.GetKeyDown(KeyCode.E) && lastInteract != null)// && interactList.Count > 0)
        {
            lastInteract.Interact(this);
            //interactList[0].Interact(this);
            //interactList.RemoveAt(0);
        }
        if (Input.GetKey(KeyCode.E) && lastInteract != null)// && interactList.Count > 0)
        {
            lastInteract.HoldInteract(this); //used for tree chopping/other long interactions
        }
        //torch
        if (Input.GetKeyDown(KeyCode.Q) && inv["torch"] > 0)
        {
            UseTorch(); //TODO
        }

        // Update UI
        gameUI.SetHealthUI(health);
        gameUI.SetTemperatureUI(100-freeze);
    }

    //move player
    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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


    //inventory
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


    //torch
    private void UseTorch()
    {
        inv["torch"] -= 1;
        Debug.Log("torch moment");
    }


    //heat
    public int GetHeat()
    {
        return heatLevel;
    }

    public void ChangeHeat(int heatToAdd)
    {
        heatLevel += heatToAdd;
    }


    //trees
    public int GetChoppingTime()
    {
        return choppingTime;
    }


    //health/damage
    public int GeHealth()
    {
        return health;
    }

    public void ChangeHealth(int healthToAdd)
    {
        health += healthToAdd;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("You Died. RIP.");
    }

    //freezing
    public void ChangeFreeze(float freezeToAdd)
    {
        //Debug.Log(freezeToAdd);
        freeze += freezeToAdd;
        if (freeze < 0)
        {
            freeze = 0;
        }
        else if (freeze > maxFreeze)
        {
            freeze = maxFreeze;
        }
    }

    public float GetFreeze()
    {
        return freeze;
    }
}



