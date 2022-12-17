using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private Settings settings;
    private PlayerController player;

    [SerializeField] Sprite nullItemSprite;

    private GameObject[] itemSlots;
    private Dictionary<string, int> itemDict;
    [SerializeField] Sprite[] itemSprites;
    [SerializeField] string[] itemList = {"wood", "stick"};

    int craftSlot = 0;
    private GameObject[] craftSlots; // 3 Crafting slots, scrollable
    [SerializeField] Sprite[] craftSprites;
    [SerializeField] string[] craftList = { "stick" };

    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        player = FindObjectOfType<PlayerController>();

        itemSlots = GameObject.FindGameObjectsWithTag("InventoryItems");
        craftSlots = GameObject.FindGameObjectsWithTag("CraftingItems");
    }

    // Update is called once per frame
    void Update() // Might want to change this to only update when the inventory changes instead of every frame
    {
        if (craftList.Length == 0 || itemList.Length == 0) return; // Don't run this script if there's no craftables or items

        itemDict = player.GetDict();

        int itemSlot = 0;
        foreach(KeyValuePair<string, int> item in itemDict)
        {
            Debug.Log(item);
            if (itemList.Contains(item.Key)) // If it's an inventory item, add to inventory
            {
                // Find the index of the sprite in itemList
                int spriteIndex = 0;
                while (!itemList[spriteIndex].Equals(item.Key))
                {
                    spriteIndex++;
                }

                // Update Icon at itemSlot
                itemSlots[itemSlot].GetComponentsInChildren<Image>()[1].sprite = itemSprites[spriteIndex];

                // Update Count at itemSlot
                itemSlots[itemSlot].GetComponentInChildren<TMP_Text>().text = "" + item.Value;

                itemSlot++;
            }
            else
            {
                Debug.Log("Item not found, define the object in the Inventory");
            }
        }
        // Blank out the rest of the inventory slots
        while (itemSlot < itemSlots.Length)
        {
            itemSlots[itemSlot].GetComponentsInChildren<Image>()[1].sprite = nullItemSprite;
            itemSlots[itemSlot].GetComponentInChildren<TMP_Text>().text = "";
            itemSlot++;
        }

        // Crafting display
        craftSlots[1].GetComponentsInChildren<Image>()[1].sprite = craftSprites[craftSlot];
        if (craftSlot < craftList.Length-1)
        {
            craftSlots[2].GetComponentsInChildren<Image>()[1].sprite = craftSprites[craftSlot + 1];
        }
        else
        {
            craftSlots[2].GetComponentsInChildren<Image>()[1].sprite = craftSprites[0];
        }
        if (craftSlot > 0)
        {
            craftSlots[0].GetComponentsInChildren<Image>()[1].sprite = craftSprites[craftSlot - 1];
        }
        else
        {
            craftSlots[0].GetComponentsInChildren<Image>()[1].sprite = craftSprites[craftList.Length-1];
        }

    }

    public void ScrollCraftingWindow(string dir)
    {
        if (dir.ToLower() == "left")
        {
            if (craftSlot > 0)
                craftSlot--;
            else
                craftSlot = craftList.Length - 1;
        }
        else if (dir.ToLower() == "right")
        {
            if (craftSlot < craftList.Length - 1)
                craftSlot++;
            else
                craftSlot = 0;
        }
        else
        {
            Debug.Log("Crafting grid button not linked correctly!");
        }
    }

}
