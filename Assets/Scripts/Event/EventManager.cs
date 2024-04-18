using System;
using System.Collections.Generic;

public static class EventManager
{
    public static event Action<List<InventoryItem>> UpdateInventoryEvent;

    public static void CallUpdateInventoryEvent(List<InventoryItem> inventoryDictionary)
    {
        if (UpdateInventoryEvent != null)
        {
            UpdateInventoryEvent(inventoryDictionary);
        }
    }
}
