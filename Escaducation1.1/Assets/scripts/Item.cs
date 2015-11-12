using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public Texture2D itemIcon;

    public Item(string name, int id)
    {
        itemName = name;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);
        itemID = id;
    }
}

