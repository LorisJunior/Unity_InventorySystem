using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    private Dictionary<int, InventoryItem> inventoryDictionary;
    [SerializeField] private SO_ItemList itemList;

    protected override void Awake()
    {
        base.Awake();

        InitializeItemDetailsDictionary();
        InitializeInventoryDictionary();
    }

    public void AddItem(int itemCode)
    {
        ItemDetails item = FindItem(itemCode);

        if (item != null)
        {
            if (item.canBePickedUp)
            {
                inventoryDictionary[itemCode].itemQuantity++;

                DebugPrintInventory();
            }
        }
        else
        {
            Debug.Log("Item Code not exist");
        }

    }

    private void InitializeItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    private void InitializeInventoryDictionary()
    {
        inventoryDictionary = new Dictionary<int, InventoryItem>();

        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            inventoryDictionary.Add(itemDetails.itemCode, new InventoryItem(itemDetails.itemCode, 0));
        }
    }

    private ItemDetails FindItem(int itemCode)
    {
        if (itemDetailsDictionary.ContainsKey(itemCode))
        {
            return itemDetailsDictionary[itemCode];
        }

        return null;
    }

    private void DebugPrintInventory()
    {
        foreach (var (key, inventoryItem) in inventoryDictionary)
        {
            if (inventoryItem.itemQuantity > 0)
            {
                ItemDetails itemDetails = FindItem(inventoryItem.itemCode);

                Debug.Log(
                    "Item Code: " + inventoryItem.itemCode +
                    " | Item Description: " + itemDetails.itemDescription +
                    " | Item Quantity: " + inventoryItem.itemQuantity);
            }
        }
        Debug.Log("*******************************************************************************************");
    }
}
