using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putOnItem : MonoBehaviour
{
    private Inventory inventory;
    private ItemDatabase database;

    private Collectible itemToAdd;
    private GameObject INV_CRAFT;
    private gameAudio aud;

    private void Start()
    {
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
        INV_CRAFT = GameObject.FindGameObjectWithTag("INV_CRAFT");
        inventory = INV_CRAFT.GetComponent<Inventory>();
        database = INV_CRAFT.GetComponent<ItemDatabase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            aud.Play("itemPickup");
            gameObject.SetActive(false);


            if (tag == "Battery")
            {
                itemToAdd = database.GetItemByName("Battery");
            }
            else if (tag == "Gem")
            {
                itemToAdd = database.GetItemByName("Gem");
            }
            else if (tag == "Metal")
            {
                itemToAdd = database.GetItemByName("Metal");
            }
            else if (tag == "Wire")
            {
                itemToAdd = database.GetItemByName("Wire");
            }
            else if (tag == "MedKit")
            {
                itemToAdd = database.GetItemByName("MedKit");
            }
            else if (tag == "Oil")
            {
                itemToAdd = database.GetItemByName("Oil");
            }
            else if (tag == "Tape")
            {
                itemToAdd = database.GetItemByName("Tape");
            }
            else if (tag == "Wrench")
            {
                itemToAdd = database.GetItemByName("Wrench");
            }

            Add(itemToAdd);
            Destroy(gameObject);
        }
    }

    void Add(Collectible itemToAdd)
    {
        inventory.AddItem(itemToAdd, itemToAdd.pickupAmount);
    }
}
