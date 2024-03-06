using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    public static InventoryUi Instance;

    public Dictionary<ItemData, GameObject> inventory = new Dictionary<ItemData, GameObject> ();
    public Transform inventoryContainer;
    public GameObject inventorySlotPrefab;


    public void Awake()
    {
        Instance = this;
    }

    public void AddInvUI(ItemData i)
    {
        if (inventory.ContainsKey(i)) return;
        inventory.Add(i, Instantiate(inventorySlotPrefab, inventoryContainer));
        inventory[i].transform.GetChild(0).GetComponent<Image>().sprite = i.icon;
    }

    public void RemoveInvUI(ItemData i)
    {
        if (inventory.ContainsKey(i))
        {
            Destroy(inventory[i]);
            inventory.Remove(i);
        }
    }
}
