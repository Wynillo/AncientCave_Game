using System.Collections.Generic;
using AncientCave.Main.ECS.Entities;

namespace AncientCave.Main.ECS.Components;

public class InventoryComponent
{
    public List<ItemEntity> Items { get; set; }

    public InventoryComponent()
    {
        Items = new List<ItemEntity>();
    }
}