using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<QuestItem> inventory;
    public int inventoryObjectCount;

    public int maxObjectInventory = 10;

    public void Awake()
    {
        Instance = this;
    }

    public static int MaxInventory()
    {
        return Instance.maxObjectInventory;
    }

    void Start()
    {
        inventoryObjectCount = 0;
    }

    
    public void RemoveFromInventory(ItemData item)
    {
        int found = inventory.FindIndex(q => q.item != null && q.item.Equals(item));
        if (found >= 0)
        {
            inventory.RemoveAt(found);
            if (!item.isInfo)
            {
                InventoryUi.Instance.RemoveInvUI(item);
            }
            inventoryObjectCount--;
            
        }
    }
    
    public void AddInventory(ItemData item)
    {
        int found = inventory.FindIndex(q => q.item.Equals(item));
        if (found < 0)
        {
            inventory.Add(new QuestItem(item));
            if (!item.isInfo)
            {
                InventoryUi.Instance.AddInvUI(item);
            }
            inventoryObjectCount++;
        }
    }
    public int GetItemIndex(ItemData questItem)
    {
        return inventory.FindIndex(q => q.item.Equals(questItem));
    }
    
    public bool HasEveryItem(List<QuestItem> requiredItems)
    {
        foreach (QuestItem item in requiredItems)
        {
            int index = GetItemIndex(item.item);
            if (index == -1)
            {
                return false;
            }
        }
        return true;
    }
}
