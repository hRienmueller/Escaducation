using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {
    public Texture2D spongeIcon;
    public Texture2D chalkIcon;
    public Texture2D emptySlot;

    private ItemDatabase database;
    private PlayerScore scoreScript;
    private GameObject EmptySlot;

    private Rect slotRect;
    private Rect Rect;
    public float x;
    public float y;

    void Start()
    {
        EmptySlot = GameObject.FindGameObjectWithTag("iconHolder");
        database = GameObject.FindGameObjectWithTag("gameController").GetComponent<ItemDatabase>();
        scoreScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        //x = EmptySlot.transform.position.x;   // x-position of the emptyslot image in screen
        //y = EmptySlot.transform.position.y;   // y-position of the emptyslot image in screen
        //x = 70;
        //y = 265;
        slotRect = new Rect(x, y, 80, 80);  //the position of the ItemIcon in screen
    }

    /*void Update()
    {
        Debug.Log( y);
    }*/
  
	public void OnGUI()
    {
        if (scoreScript.currentExtra == "sponge")  //if the extra the player just walked throug was the sponge
        {
            //ResetInventory();
            GUI.DrawTexture(slotRect, spongeIcon);   //draw the sponge Icon
            //Debug.Log("Drawed icon sponge...");
        }

        if (scoreScript.currentExtra == "chalk")  //if it was the chalk...
        {
            //ResetInventory();
            GUI.DrawTexture(slotRect, chalkIcon);   //...draw the chalk Icon
            //Debug.Log("Drawed icon chalk...");
        }
        if (Input.GetButtonUp("Action"))   //if player uses the item
        {
            GUI.DrawTexture(slotRect, emptySlot);  // clear the iventory to not hold any extra
            scoreScript.currentExtra = "";         // set current extra to nothing
            //Debug.Log(scoreScript.currentExtra);
        }
    }
    

    public bool InventoryContains(string itemName)  //check if the player carries a certain item
    {
        bool result = false;
        if (scoreScript.currentExtra == itemName) // if current extra is equal to the name of the Extra
        {
            Debug.Log("Extra found in inventory");
            result = true;            //the result of InventoryContains is true
        }
       // Debug.Log("result");
        return result; //return the result
    }
}
