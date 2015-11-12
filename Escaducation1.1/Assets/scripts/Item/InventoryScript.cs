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
        slotRect = new Rect(x, y, 80, 80);
    }

    void Update()
    {
        Debug.Log( y);
    }
  
	public void OnGUI()
    {
        if (scoreScript.currentExtra == "sponge")
        {
            //ResetInventory();
            GUI.DrawTexture(slotRect, spongeIcon);
            //Debug.Log("Drawed icon sponge...");
        }

        if (scoreScript.currentExtra == "chalk")
        {
            //ResetInventory();
            GUI.DrawTexture(slotRect, chalkIcon);
            //Debug.Log("Drawed icon chalk...");
        }
    }
    
    public void ResetInventory()
    {
        GUI.DrawTexture(slotRect, emptySlot);
    }
}
