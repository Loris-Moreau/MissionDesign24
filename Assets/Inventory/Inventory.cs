using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<QuestItem> inventory;
    public int inventoryTotalCount;
    public int inventoryObjectCount;
    public int inventoryIdeaCount;

    public int maxInventory = 10;

    public ItemData trst;
    public QuestItem test1;
    public QuestItem test2;
    public QuestItem test3;


    public void Awake()
    {
        Instance = this;
    }

    public static int MaxInventory()
    {
        return Instance.maxInventory;
    }

    void Start()
    {
        inventoryTotalCount = 0;
        inventoryObjectCount = 0;
        inventoryIdeaCount = 0; 
    }

    public void TestInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AddInventory(trst);
        }        
    }

    public void TestRemoveInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RemoveFromInventory(trst);
        }
    }

    /*public void AddInventory(QuestItem i)
    {
        if (InventoryUi.Instance.inventory.ContainsKey(i))
        {
            Debug.LogWarning("Je suis d�j� full");
            return;
        }
        inventoryTotalCount++;
        Debug.Log("+1 dans l'inventaire !");
        inventory.Add(i);

        if (!i.item.isInfo)
        {
            inventoryObjectCount++;
            InventoryUi.Instance.AddInvUI(i);
        }
        else if (i.item.isInfo)
        {
            inventoryIdeaCount++;
        }
    }

    public void RemoveFromInventory(QuestItem i)
    {
        if (inventoryTotalCount == 0)
        {
            //message erreur
        }
        else
        {
            inventoryTotalCount--;
            Debug.Log("-1 dans l'inventaire !");
            inventory.Remove(i);
            
            if(!i.item.isInfo) 
            {
                InventoryUi.Instance.RemoveInvUI(i);
                inventoryObjectCount--;
            }
            else if (i.item.isInfo)
            {
                inventoryIdeaCount--;
            }
        }
    }*/
    
    public void RemoveFromInventory(ItemData item)
    {
        int found = inventory.FindIndex(q => q.item != null && q.item.Equals(item));
        if (found >= 0)
        {
            inventory.RemoveAt(found);
        }
    }
    
    public void AddInventory(ItemData item)
    {
        int found = inventory.FindIndex(q => q.item.Equals(item));
        if (found < 0)
        {
            inventory.Add(new QuestItem(item));
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
