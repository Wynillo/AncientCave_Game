// EnemyEntity.cs

using System.Numerics;
using AncientCave.GameCore.Components;

namespace AncientCave.GameCore.Entities;

public class EnemyEntity : Entity
{
    public Vector2 Position { get; set; }
    public RenderComponent RenderComponent { get; set; }
    public int Health { get; set; }
}