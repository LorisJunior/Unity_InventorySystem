using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemCode;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
