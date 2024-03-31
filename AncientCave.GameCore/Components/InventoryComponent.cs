using AncientCave.GameCore.Entities;

namespace AncientCave.GameCore.Components;

public class InventoryComponent
{
    public List<ItemEntity> Items { get; set; }

    public InventoryComponent()
    {
        Items = new List<ItemEntity>();
    }
}