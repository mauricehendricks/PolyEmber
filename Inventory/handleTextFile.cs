using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleTextFile : MonoBehaviour
{
    string filepath;
    public string ReadString(string path, bool isCraftingTable)
    {
        if (!isCraftingTable)
        {
            filepath = "Descriptions/" + path;
        }
        else
        {
            filepath = "Recipes/" + path;
        }
        
        TextAsset textFile = Resources.Load(filepath) as TextAsset;

        string description = textFile.text;
        return (description);
    }
}