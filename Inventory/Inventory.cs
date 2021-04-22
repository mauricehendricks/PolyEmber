using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    public bool inventory_isActive = false;
    public bool craftingTutorial = false;
    public GameObject inventory_UI;
    public GameObject crossHair;
    public GameObject freeLookCam;
    public GameObject tutorialText;
    public GameObject tabText;
    public GameObject craftingText;

    // ===== Inventory Section ===== //
    public List<GameObject> slots = new List<GameObject>();
    
    [HideInInspector]
    public bool isDragging = false;
    public Image draggingImage = null;
    [HideInInspector]
    public Collectible draggingItem;
    [HideInInspector]
    public int draggingAmount;

    public GameObject toolTipPanel;
    public TextMeshProUGUI toolTipText;

    private PlayerHealth playerHealth;
    private handleTextFile itemDescription;
    private CharacterAiming aiming;
    private TopDownCharacterMover movement;
    private gameAudio aud;
    private CharacterLocomotion locomotion;
    

    private void Start()
    {
        
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        itemDescription = GetComponent<handleTextFile>();
        aiming = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAiming>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownCharacterMover>();
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
        locomotion = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLocomotion>();
        inventory_UI.SetActive(false);

    }

    public bool AddItem(Collectible itemToAdd, int amount)
    {
        
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToAdd && itemToAdd.isStackable && currentSlot.myAmount + amount <= itemToAdd.maxStackAmount)
            {
                currentSlot.AddItem(itemToAdd, amount);
                return true;
            } else if (currentSlot.myItem == null && emptySlot == null)
            {
                //print("Item added");
                emptySlot = currentSlot;
            }
        }

        if (emptySlot != null)
        {
            emptySlot.AddItem(itemToAdd, amount);
            return true;
        } else
        {
            print("Inventory is full");
            return false;
        }
    }

    public void RemoveItem(Collectible itemToRemove, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToRemove)
            {
                currentSlot.RemoveItem(amount);
            }
        }
    }

    public bool HasItem(string theItem, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<Slot>().myItem != null)
            {
                if (slots[i].GetComponent<Slot>().myItem.itemName == theItem && slots[i].GetComponent<Slot>().myAmount >= amount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void DoDrag(Collectible itemToDrag, int amount)
    {
        draggingItem = itemToDrag;

        isDragging = true;
        draggingImage.enabled = true;
        draggingImage.sprite = draggingItem.icon;
        draggingAmount = amount;
    }

    public void EndDrag()
    {
        draggingItem = null;
        isDragging = false;
        draggingImage.enabled = false;
        draggingAmount = 0;
    }

    public void ShowToolTip(Collectible toolTipItem, bool isCraftingTable)
    {
        toolTipPanel.SetActive(true);
        toolTipText.text = toolTipItem.itemName + "\n" + "\n" + itemDescription.ReadString(toolTipItem.itemName, isCraftingTable);

    }

    public void HideToolTip()
    {
        toolTipPanel.SetActive(false);
    }

    public void useItem(Collectible myItem)
    {
        if (myItem.itemName == "Battery")
        {
            RemoveItem(myItem, 1);
            playerHealth.increaseHealth(50);
            aud.Play("charge");
            
        } else
        {
            print("item used");
        }
    }

    void Update()
    {
        if (!inventory_isActive)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory_UI.SetActive(true);
                inventory_isActive = true;
                tabText.SetActive(false);

                aiming.enabled = false;
                movement.enabled = false;
                locomotion.stopMovement();
                locomotion.enabled = false;
                freeLookCam.SetActive(false);

                tutorialText.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                crossHair.SetActive(false);


                if (craftingTutorial && playerHealth.energy <= 40)
                {
                    craftingText.SetActive(true);
                }

                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].GetComponent<Slot>().myItem != null)
                    {
                        Slot currentSlot = slots[i].GetComponent<Slot>();
                        currentSlot.ShowUI();
                    }
                }   
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                HideToolTip();
                inventory_UI.SetActive(false);
                inventory_isActive = false;
                tutorialText.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                crossHair.SetActive(true);
                aiming.enabled = true;
                movement.enabled = true;
                locomotion.enabled = true;
                freeLookCam.SetActive(true);
                craftingText.SetActive(false);
            }
        }   
    }
}
