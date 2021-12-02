using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] UI_Inventory _ui_inventory;
    void Start()
    {
        _inventory = new Inventory();

        _inventory.AddItem(new Item() { amount = 1, itemType = Item.ItemType.Grenade });
        _inventory.AddItem(new Item() { amount = 1, itemType = Item.ItemType.Molotov });


        _ui_inventory.SetPlayer(this);
        _ui_inventory.SetInventory(_inventory);
    }
}
