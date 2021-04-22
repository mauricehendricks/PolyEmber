using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Inventory inventory;
    private Image myImage;
    private TextMeshProUGUI myText;
    Slider durabilityBar;

    private GameObject inventory_UI;
    public Collectible myItem;
    public int myAmount;

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        myImage = transform.GetChild(0).GetComponent<Image>();
        myText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        durabilityBar = transform.GetChild(2).GetComponent<Slider>();
        ShowUI();
    }

    public void AddItem(Collectible itemToAdd, int amount)
    {
        if (itemToAdd == myItem)
        {
            myAmount += amount;
        } else
        {
            myItem = itemToAdd;
            myAmount = amount;
        }
        ShowUI();
    }

    public void RemoveItem(int amount)
    {
        if (myItem != null)
        {
            myAmount -= amount;
            if (myAmount <= 0)
            {
                myItem = null;
                inventory.HideToolTip();
            }
        }
        ShowUI();
    }

    public void ShowUI()
    {
        if (myItem != null)
        {
            myImage.enabled = true;
            myText.enabled = true;
            myImage.sprite = myItem.icon;
            myText.text = myAmount.ToString();
            myImage.preserveAspect = true;

            if (myItem.useDurability)
            {
                durabilityBar.gameObject.SetActive(true);
                durabilityBar.maxValue = myItem.maxDurability;
                durabilityBar.value = myItem.currentDurability;
            }
            else
            {
                durabilityBar.gameObject.SetActive(false);
            }
        }
        else
        {
            myImage.enabled = false;
            myText.enabled = false;
            durabilityBar.gameObject.SetActive(false);
        }
    }

    /* Inventory Dragging Section
     * Add These Handlers at the top if wanted: IBeginDragHandler, IDragHandler, IDropHandler,

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (myItem != null)
        {
            inventory.DoDrag(myItem, myAmount);
            RemoveItem(myAmount);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.draggingImage.transform.position = Input.mousePosition;
    }
    public void OnDrop(PointerEventData eventData)
    {
        AddItem(inventory.draggingItem, inventory.draggingAmount);
        inventory.EndDrag();
    }
    */
    public void OnPointerClick(PointerEventData eventData)
    {
        if (myItem != null)
        {
            inventory.useItem(myItem);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (myItem != null)
        {
           inventory.ShowToolTip(myItem, false);
        } 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (myItem != null)
        {
            inventory.HideToolTip();
        }
    }
}
