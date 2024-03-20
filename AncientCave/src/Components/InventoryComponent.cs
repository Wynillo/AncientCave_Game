using System.Collections.Generic;
using AncientCave.Entities;

namespace AncientCave.Components;

public class InventoryComponent
{
    public List<ItemEntity> Items { get; set; }

    public InventoryComponent()
    {
        Items = new List<ItemEntity>();
    }
}