// EnemyEntity.cs

using System.Numerics;
using AncientCave.ECS.Components;

namespace AncientCave.ECS.Entities;

public class EnemyEntity
{
    public Vector2 Position { get; set; }
    public RenderComponent RenderComponent { get; set; }
    public int Health { get; set; }
}