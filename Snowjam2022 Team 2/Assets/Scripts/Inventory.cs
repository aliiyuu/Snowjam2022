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

    private GameObject[] itemSlots;
    private Dictionary<string, int> itemDict;
    [SerializeField] Sprite nullItemSprite;
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
            Debug.Log(item);
            if (itemList.Contains(item.Key))
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
