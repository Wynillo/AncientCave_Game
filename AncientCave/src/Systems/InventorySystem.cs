using AncientCave.Entities;
using AncientCave.Components;

namespace AncientCave.Systems;

public class InventorySystem
{
    public void AddItem(InventoryComponent inventory, ItemEntity item)
    {
        inventory.Items.Add(item);
    }

    public bool RemoveItem(InventoryComponent inventory, ItemEntity item)
    {
        return inventory.Items.Remove(item);
    }

    public bool HasItem(InventoryComponent inventory, ItemEntity item)
    {
        return inventory.Items.Contains(item);
    }
}