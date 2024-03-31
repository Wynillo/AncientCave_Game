// PlayerEntity.cs

using System.Numerics;
using AncientCave.GameCore.Components;

namespace AncientCave.GameCore.Entities;

public class PlayerEntity : Entity
{
    public Vector2 Position { get; set; }
    public RenderComponent RenderComponent { get; set; }
    public int Health { get; set; }
    public InventoryComponent InventoryComponent { get; set; } // Replace with your own Inventory class
}