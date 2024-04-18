using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    public GameObject inventoryDraggedItem;

    [SerializeField] private Sprite transparent32x32;
    [SerializeField] private UIInventorySlot[] inventorySlots;

    private void OnEnable()
    {
        EventManager.UpdateInventoryEvent += UpdateInventory;
    }

    private void OnDisable()
    {
        EventManager.UpdateInventoryEvent -= UpdateInventory;
    }

    private void UpdateInventory(List<InventoryItem> inventoryList)
    {
        ClearInventorySlots();

        int slotsCount = 0;

        foreach (var inventoryItem in inventoryList)
        {
            if(slotsCount == inventorySlots.Length)
                break;

            ItemDetails itemDetail = InventoryManager.Instance.FindItem(inventoryItem.itemCode);

            UIInventorySlot inventorySlot = inventorySlots[slotsCount];

            inventorySlot.SetInventorySlot(itemDetail.itemSprite, $"x{inventoryItem.itemQuantity}", itemDetail, inventoryItem.itemQuantity);

            slotsCount++;
        }
    }

    private void ClearInventorySlots()
    {
        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.ClearInventorySlot(transparent32x32);
        }
    }
}
