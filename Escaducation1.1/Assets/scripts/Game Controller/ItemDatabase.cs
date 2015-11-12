using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    
    void Start()   //fill the database with all the items
    {
        items.Add(new Item("sponge", 0));
        items.Add(new Item("chalk", 1));
    }
}
