using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHeat : Interactable
{

   
    private HeatSource heatSource;
    private float heatTimer;
    [SerializeField]
    private float heatDegradeTime;
    private Animator animator;

       

        // Start is called before the first frame update
    void Awake()
    {
        //heatSource = gameObject.GetComponent<HeatSource>(); //doesn't work due to multi-part setup for fire
        heatSource = gameObject.GetComponentInChildren<HeatSource>();
        animator = GetComponent<Animator>();

    }

    public override void Interact(PlayerController playerController)
    {
        Debug.Log("This should show when you hit E, or I broke something lol");
        if(heatSource.player.GetItem("wood") > 0 && heatSource.GetHeatLevel() < heatSource.GetMaxHeat())
        {
            //heat source gets HOTTER with more fuel (and resets the burn timer) - comment this out if you want the other version. This is stronger, as each degrade reduces heat and restarts the timer
            heatSource.ChangeHeatLevel(1);
            heatSource.player.RemoveItem("wood");
            heatTimer = 0;

            //uncomment this if you want the fire to burn only longer with more fuel - aka weaker.
            /*
            if(heatSource.GetHeatLevel() > heatSource.GetMinHeat())
            {
                heatTimer -= heatDegradeTime;
                heatSource.player.RemoveItem("wood");
            }
            else
            {
                heatSource.ChangeHeatLevel(1);
                heatSource.player.RemoveItem("wood");
                heatTimer = 0;
            }
            */
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if(heatSource.GetHeatLevel() > heatSource.GetMinHeat())
        {
            heatTimer += Time.deltaTime;
            if (heatTimer >= heatDegradeTime)
            {
                heatTimer = 0;
                heatSource.ChangeHeatLevel(-1); //fire degrades one heat level per timer decrement
            }
        }

        //play animations
        DoAnimation();

    }

    public virtual void DoAnimation()
    {
        if(heatSource.GetHeatLevel() > heatSource.GetMinHeat())
        {
            animator.SetBool("FireOn", true);
        }
        else
        {
            animator.SetBool("FireOn", false);
        }
    }

}

