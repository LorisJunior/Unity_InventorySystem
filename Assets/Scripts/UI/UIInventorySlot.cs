using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // Components

    public Image inventorySelectedImage;
    public Image InventoryImage;
    public TextMeshProUGUI textMeshProUGUI;

    // Item

    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemQuantity = 0;

    // Drag item

    [SerializeField] private UIInventoryBar inventoryBar;
    private GameObject draggedItem;
    private Camera mainCamera;
    public GameObject itemPrefab;
    private Transform itemsContainer;


    private void Start()
    {
        mainCamera = Camera.main;
        itemsContainer = GameObject.FindGameObjectWithTag("ItemsContainer").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemQuantity > 0)
        {
            draggedItem = Instantiate(inventoryBar.inventoryDraggedItem, inventoryBar.transform);
            draggedItem.GetComponentInChildren<Image>().sprite = InventoryImage.sprite;
            inventorySelectedImage.color = new Color(1,1,1,1);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            Destroy(draggedItem);

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

            GameObject itemGameObject = Instantiate(itemPrefab, worldPosition, Quaternion.identity, itemsContainer);

            Item item = itemGameObject.GetComponentInChildren<Item>();
            item.itemCode = itemDetails.itemCode;
            item.spriteRenderer.sprite = itemDetails.itemSprite;

            inventorySelectedImage.color = new Color(1,1,1,0);

            InventoryManager.Instance.RemoveItem(itemDetails.itemCode);
        }
    }

    public void SetInventorySlot(Sprite image, string text, ItemDetails details, int quantity)
    {
        InventoryImage.sprite = image;
        textMeshProUGUI.text = text;
        itemDetails = details;
        itemQuantity = quantity;
    }

    public void ClearInventorySlot(Sprite transparent32x32)
    {
        inventorySelectedImage.color = new Color(1, 1, 1, 0);
        InventoryImage.sprite = transparent32x32;
        textMeshProUGUI.text = string.Empty;
        itemDetails = null;
        itemQuantity = 0;
    }
}
