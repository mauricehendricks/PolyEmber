using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAdd : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.AddItem(dataBase.GetItemById(0), 1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            inventory.AddItem(dataBase.GetItemById(1), 1);
        }

        /*if (Input.GetKeyDown(KeyCode.M))
        {
            inventory.AddItem(dataBase.GetItemById(2), 1);
        }*/
    }
}
