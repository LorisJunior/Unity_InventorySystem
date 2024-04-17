using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (!item || !InventoryManager.Instance.FindItem(item.itemCode).canBePickedUp)
            return;

        InventoryManager.Instance.AddItem(item.itemCode);

        Destroy(other.gameObject);
    }
}
