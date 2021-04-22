using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inventory;

    public GameObject craftingPanel;
    public GameObject craftingSlot;

    private gameAudio aud;

    public int playerLevel;

    private void Start()
    {
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
        GenSlots();   
    }

    void GenSlots()
    {
        for (int i = 0; i < dataBase.itemDatabase.Count; i++)
        {
            Collectible currentItem = dataBase.itemDatabase[i];
            if (currentItem.isCraftable && playerLevel >= currentItem.minLevelToCraft)
            {
                GameObject go = Instantiate(craftingSlot, craftingPanel.transform.position, Quaternion.identity);
                go.transform.SetParent(craftingPanel.transform);
                go.transform.localScale = new Vector3(1f, 1f, 1f);
                go.GetComponent<CraftingSlot>().myItem = currentItem;
            }
        }
    }

    public void CraftItem(Collectible itemToCraft)
    {
        if (itemToCraft.isCraftable)
        {
            if (canCraft (itemToCraft))
            {
                Add(itemToCraft);
                aud.Play("itemPickup");
            } else
            {
                print("cant craft that item");
            }
        } else
        {
            return;
        }
    }

    bool canCraft (Collectible itemToLookUP)
    {
        for (int i = 0; i < itemToLookUP.craftItems.Count; i++)
        {
            Collectible currentItem = itemToLookUP.craftItems[i];
            int currentAmount = itemToLookUP.craftAmount[i];

            if (!inventory.HasItem(currentItem.itemName, currentAmount))
            {
                return false;
            }
            
        }
        return true;
    }

    void Add (Collectible itemToAdd)
    {
        inventory.AddItem(itemToAdd, itemToAdd.makesHowMany);
        Remove(itemToAdd);
    }

    void Remove (Collectible itemToRemove)
    {
        for (int i = 0; i < itemToRemove.craftItems.Count; i++)
        {
            Collectible currentItem = itemToRemove.craftItems[i];
            int currentAmount = itemToRemove.craftAmount[i];
            inventory.RemoveItem(currentItem, currentAmount);
        }
    }
}
 