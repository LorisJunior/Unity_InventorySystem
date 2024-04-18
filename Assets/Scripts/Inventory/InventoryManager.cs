using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    private List<InventoryItem> inventoryList;
    [SerializeField] private SO_ItemList itemList;

    protected override void Awake()
    {
        base.Awake();

        InitializeItemDetailsDictionary();
        InitializeInventoryList();
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

    private void InitializeInventoryList()
    {
        inventoryList = new List<InventoryItem>();
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
            inventoryItem.itemQuantity++;
        }
        else
        {
            inventoryList.Add(new InventoryItem(itemCode, 1));
        }

        EventManager.CallUpdateInventoryEvent(inventoryList);
    }

    public void RemoveItem(int itemCode)
    {
        InventoryItem inventoryItem = FindItemInInventory(itemCode);

        if (inventoryItem.itemQuantity > 1)
        {
            inventoryItem.itemQuantity--;
        }
        else
        {
            inventoryList.Remove(inventoryItem);
        }

        EventManager.CallUpdateInventoryEvent(inventoryList);
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
        InventoryItem inventoryItem = inventoryList.Find(x => x.itemCode == itemCode);

        if (inventoryItem != null)
        {
            return inventoryItem;
        }

        return null;
    }

    #endregion
}
