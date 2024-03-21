using System.Collections.Generic;
using AncientCave.ECS.Entities;

namespace AncientCave.ECS.Components;

public class InventoryComponent
{
    public List<ItemEntity> Items { get; set; }

    public InventoryComponent()
    {
        Items = new List<ItemEntity>();
    }
}