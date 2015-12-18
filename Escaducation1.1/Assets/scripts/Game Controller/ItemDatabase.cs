using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    
    void Start()   //fill the database with all the items
    {
        items.Add(new Item("sponge", 0));   //stunns the enemy
        items.Add(new Item("Paperthingy", 1));    //distrackts enemy, so that he does not hunt you but instead goes somewhere else
        items.Add(new Item("Sausage", 2));     //stunns the dog. ONLY the dog.
    }
}
