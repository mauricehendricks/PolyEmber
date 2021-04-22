using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addToInventory : MonoBehaviour
{
    private Inventory inventory;
    private ItemDatabase database;
    private Collectible item;
    private GameObject INV_CRAFT;

    public bool metalGot = false;
    public bool oilGot = false;
    public bool gemGot = false;
    public GameObject shippingUI;
    public GameObject campsiteUI;
    public GameObject waterTowerUI;

    private CharacterLocomotion locomotion;
    private TopDownCharacterMover movement;
    private gameAudio aud;
    public GameObject freeLookCam;

    private void Start()
    {
        INV_CRAFT = GameObject.FindGameObjectWithTag("INV_CRAFT");
        inventory = INV_CRAFT.GetComponent<Inventory>();
        database = INV_CRAFT.GetComponent<ItemDatabase>();
        locomotion = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLocomotion>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownCharacterMover>();
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
    }

    public void AddMetal ()
    {
        if (!metalGot)
        {
            item = database.GetItemByName("Metal");
            Add(item, 10);
            item = database.GetItemByName("Wire");
            Add(item, 10);
            metalGot = true;
            aud.Play("itemPickup");
        }
        campsiteUI.SetActive(false);
        unfreezePlayer();
    }

    public void AddOil ()
    {
        if (!oilGot)
        {
            item = database.GetItemByName("Oil");
            Add(item, 5);
            oilGot = true;
            aud.Play("itemPickup");
        }
        waterTowerUI.SetActive(false);
        unfreezePlayer();
    }

    public void AddGem ()
    {
        if (!gemGot)
        {
            item = database.GetItemByName("Gem");
            Add(item, 1);
            gemGot = true;
            aud.Play("itemPickup");
        }
        shippingUI.SetActive(false);
        unfreezePlayer();
    }

    void unfreezePlayer ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        freeLookCam.SetActive(true);
        locomotion.enabled = true;
        movement.enabled = true;
    }

    void Add(Collectible theItem, int amount)
    {
        inventory.AddItem(theItem, amount);
    }
}
