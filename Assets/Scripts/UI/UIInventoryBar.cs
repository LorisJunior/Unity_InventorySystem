using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
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

    private void UpdateInventory(Dictionary<int, InventoryItem> inventoryDictionary)
    {
        ClearInventorySlots();

        int count = 0;

        foreach (var (itemCode, inventoryItem) in inventoryDictionary)
        {
            if(count > inventorySlots.Length)
                break;

            ItemDetails itemDetail = InventoryManager.Instance.FindItem(itemCode);

            var inventorySlot = inventorySlots[count];

            inventorySlot.InventoryImage.sprite = itemDetail.itemSprite;
            inventorySlot.textMeshProUGUI.text = $"x{inventoryItem.itemQuantity}";

            count++;
        }
    }

    private void ClearInventorySlots()
    {
        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.inventorySelectedImage.color = new Color(1, 1, 1, 0);
            inventorySlot.InventoryImage.sprite = transparent32x32;
            inventorySlot.textMeshProUGUI.text = string.Empty;
        }
    }
}
