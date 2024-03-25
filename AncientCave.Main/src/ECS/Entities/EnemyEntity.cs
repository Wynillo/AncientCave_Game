// EnemyEntity.cs

using System.Numerics;
using AncientCave.Main.ECS.Components;

namespace AncientCave.Main.ECS.Entities;

public class EnemyEntity : Entity
{
    public Vector2 Position { get; set; }
    public RenderComponent RenderComponent { get; set; }
    public int Health { get; set; }
}