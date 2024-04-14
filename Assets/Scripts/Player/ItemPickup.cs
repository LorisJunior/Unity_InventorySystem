using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (!item)
            return;

        InventoryManager.Instance.AddItem(item.itemCode);
    }
}
