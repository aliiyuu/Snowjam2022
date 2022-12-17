using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHeat : Interactable
{

   
    private HeatSource heatSource;

    // Start is called before the first frame update
    void Start()
    {
        //heatSource = gameObject.GetComponent<HeatSource>(); //doesn't work due to multi-part setup for fire
        heatSource = gameObject.GetComponentInChildren<HeatSource>();

    }

    public override void Interact(PlayerInteract playerInteract)
    {
        //todo: check for fuel
        heatSource.ChangeHeatLevel(1);
        //todo: start timer
    }

    // Update is called once per frame
    void Update()
    {
    }
}
