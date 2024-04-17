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



    #region Initialize Dictionaries



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
    }

    #endregion



    #region Inventory Functions



    public void AddItem(int itemCode)
    {
        ItemDetails item = FindItem(itemCode);

        if(item == null)
        {
            Debug.Log("Item Code not exist");
            return;
        }
        
        InventoryItem inventoryItem = FindItemInInventory(itemCode);

        if(inventoryItem != null)
        {
            inventoryDictionary[itemCode].itemQuantity++;

            EventManager.CallUpdateInventoryEvent(inventoryDictionary);
        }
        else
        {
            inventoryDictionary.Add(itemCode, new InventoryItem(itemCode, 1));

            EventManager.CallUpdateInventoryEvent(inventoryDictionary);
        }
    }

    public ItemDetails FindItem(int itemCode)
    {
        if (itemDetailsDictionary.ContainsKey(itemCode))
        {
            return itemDetailsDictionary[itemCode];
        }

        return null;
    }

    private InventoryItem FindItemInInventory(int itemCode)
    {
        if (inventoryDictionary.ContainsKey(itemCode))
        {
            return inventoryDictionary[itemCode];
        }

        return null;
    }

    private void DebugPrintInventory()
    {
        foreach (var (itemCode, inventoryItem) in inventoryDictionary)
        {
            ItemDetails itemDetails = FindItem(itemCode);

            Debug.Log(
                "Item Code: " + itemCode +
                " | Item Description: " + itemDetails.itemDescription +
                " | Item Quantity: " + inventoryItem.itemQuantity);
        }
        Debug.Log("*******************************************************************************************");
    }

    #endregion
}
