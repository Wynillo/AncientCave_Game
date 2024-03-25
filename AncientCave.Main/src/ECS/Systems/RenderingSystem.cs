using System.Collections.Generic;
using AncientCave.Main.ECS.Components;

namespace AncientCave.Main.ECS.Systems;

public class RenderingSystem
{
    private readonly List<RenderComponent> _renderComponents = new List<RenderComponent>();

    public void AddComponent(RenderComponent component)
    {
        _renderComponents.Add(component);
    }

    public void RemoveComponent(RenderComponent component)
    {
        _renderComponents.Remove(component);
    }

    public void Render()
    {
        foreach (var component in _renderComponents)
        {
            // Retrieve the necessary information from component
            var sprite = component.Sprite;
            var position = component.Position;

            // Render the sprite at the given position.
            // This would use your actual rendering logic.
        }
    }
}