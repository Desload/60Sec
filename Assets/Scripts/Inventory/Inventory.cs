using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items;
    public List<Item> GetListItem => items;
    
    public Inventory()
    {
        items = new List<Item>();

        Debug.Log($"Inventory successfully created.");
    }
    public void AddItem(Item item)
    {        
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;            
            foreach(Item i in items)
            {
                if(i.itemType == item.itemType)
                {
                    i.amount++;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                items.Add(item);
            }
        }
        else
            items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item i in items)
            {
                if (i.itemType == item.itemType)
                {
                    i.amount--;
                    itemInInventory = i;
                }
                if (itemInInventory.amount <= 0 && itemInInventory != null)
                    items.Remove(itemInInventory);
            }
        }
        else
            items.Remove(item);
    }


}
