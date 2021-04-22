using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Collectible> itemDatabase = new List<Collectible>();
    
    public Collectible GetItemById(int id)
    {
        Collectible itemToReturn = itemDatabase[id];
        return itemToReturn;
    }

    public Collectible GetItemByName(string name)
    {
        Collectible itemToReturn = null;
        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].itemName == name)
            {
                itemToReturn = itemDatabase[i];
            }
        }

        return itemToReturn;
    }
}
