using System;
using System.Numerics;
using AncientCave.ECS.Components;

namespace AncientCave.ECS.Systems;

public class MovementSystem
{
    public void UpdatePosition(MovementComponent movementComponent, ref Vector2 position, float deltaTime)
    {
        if (movementComponent == null)
        {
            throw new ArgumentNullException(nameof(movementComponent));
        }

        // Add logging to trace behavior
        Console.WriteLine($"Before update - Velocity: {movementComponent.CurrentVelocity}, Position: {position}");

        // Update velocity
        movementComponent.UpdateVelocity(deltaTime);

        // Update position based on velocity
        position += movementComponent.CurrentVelocity * deltaTime;

        // Add logging to trace behavior
        Console.WriteLine($"After update - Velocity: {movementComponent.CurrentVelocity}, Position: {position}");
    }
}