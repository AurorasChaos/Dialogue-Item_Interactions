using System.Collections.Generic;
using UnityEngine;

public class Item_Base 
{
    private int id;
    private string itemName;
    private string itemDescription;
    private Sprite itemIcon;
    private List<int> itemsToCombineWith;
    private int itemToMakeFromCombination;

    public Item_Base(int id, string itemName, string itemDescription, List<int> itemsToCombineWith, int itemToMakeFromCombination)
    {
        this.id = id;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemIcon = Resources.Load<Sprite>("Assets/Sprites/Items/" + itemName);
        this.itemsToCombineWith = itemsToCombineWith;
        this.itemToMakeFromCombination = itemToMakeFromCombination;

    }

    public int getItemId()
    {
        return this.id;
    }

    public string getItemName()
    {
        return this.itemName;
    }

    public string getItemDescription()
    {
        return this.itemDescription;
    }

    public Sprite getItemIcon()
    {
        return this.itemIcon;
    }

    public List<int> getItemsNeededForCombination()
    {
        return this.itemsToCombineWith;
    }

    public int getItemToCombineInto()
    {
        return this.itemToMakeFromCombination;
    }

}
