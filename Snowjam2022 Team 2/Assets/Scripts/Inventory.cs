using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Settings settings;
    private PlayerController player;

    private GameObject[] itemSlots;
    private Dictionary<string, int> itemDict;
    [SerializeField] Sprite[] itemSprites;
    [SerializeField] string[] itemList = {"wood"};

    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        player = FindObjectOfType<PlayerController>();

        itemSlots = GameObject.FindGameObjectsWithTag("InventoryItems");
    }

    // Update is called once per frame
    void Update() // Might want to change this to only update when the inventory changes instead of every frame
    {
        itemDict = player.GetDict();

        int itemSlot = 0;
        foreach(KeyValuePair<string, int> item in itemDict)
        {
            if (itemList.Contains(item.Key))
            {

                // Update Icon at itemSlot


                // Update Count at itemSlot


            }
            else
            {
                Debug.Log("Item not found, define the object in the Inventory");
            }
        }

        int itemSlotIndex = 0;
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemDict.ContainsKey(itemList[i]))
            {

            }
        }

        // "wood"

    }
}
