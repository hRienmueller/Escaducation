using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public Texture2D itemIcon;

    public Item(string name, int id)  // setup te new class Item with a name, an icon and an id to quickly access one specific item
    {
        itemName = name;     //the name of the item
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);  //the icon of the item
        itemID = id;     //the id of the item
    }   
}

