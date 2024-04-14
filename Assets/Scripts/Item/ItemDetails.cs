using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemCode;
    public Sprite itemSprite;
    public ItemCategory itemCategory;
    public string itemDescription;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool canBeCarried;
}
