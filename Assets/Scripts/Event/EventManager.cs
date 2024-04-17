using System;
using System.Collections.Generic;

public static class EventManager
{
    public static event Action<Dictionary<int, InventoryItem>> UpdateInventoryEvent;

    public static void CallUpdateInventoryEvent(Dictionary<int, InventoryItem> inventoryDictionary)
    {
        if (UpdateInventoryEvent != null)
        {
            UpdateInventoryEvent(inventoryDictionary);
        }
    }
}
