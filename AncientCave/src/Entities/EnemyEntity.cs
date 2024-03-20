// EnemyEntity.cs
using System.Numerics;
using AncientCave.Components;

namespace AncientCave.Entities;

public class EnemyEntity
{
    public Vector2 Position { get; set; }
    public RenderComponent RenderComponent { get; set; }
    public int Health { get; set; }
}