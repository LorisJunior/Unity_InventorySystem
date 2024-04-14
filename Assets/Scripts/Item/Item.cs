using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemCode;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
