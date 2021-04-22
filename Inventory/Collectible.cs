using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectible : ScriptableObject
{
    // General Info
    public string itemName;
    public Sprite icon;

    // Stack info
    public bool isStackable;
    public int maxStackAmount;
    public int pickupAmount;

    // Durability info
    public bool useDurability;
    public int maxDurability;
    public int currentDurability;
    

    // Craft info
    public bool isCraftable;
    public List<Collectible> craftItems = new List<Collectible>();
    public List<int> craftAmount = new List<int>();
    public int minLevelToCraft;
    public int makesHowMany;
}