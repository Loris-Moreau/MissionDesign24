using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public InventoryManagement instance;

    public SOQuestItem[] inventory;
    public Transform[] displayInv;
    public int inventoryCapacity;
    public int inventoryCount;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inventory = new SOQuestItem[inventoryCapacity];
    }


    void Update()
    {
        foreach (SOQuestItem i in inventory)
        {
            Instantiate(i.sprite, displayInv[inventoryCount - 1]);
        }
    }

    public void AddInventory(SOQuestItem i)
    {
        inventoryCount++;
        inventory[inventoryCount] = i;
    }
}
