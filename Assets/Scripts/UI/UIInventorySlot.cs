using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventorySlot : MonoBehaviour
{
    // Components

    public Image inventorySelectedImage;
    public Image InventoryImage;
    public TextMeshProUGUI textMeshProUGUI;

    // Item details

    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemQuantity;
}
