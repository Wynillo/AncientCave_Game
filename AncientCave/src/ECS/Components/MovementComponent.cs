using System;
using System.Numerics;

namespace AncientCave.ECS.Components;

public class MovementComponent
{
    // Add these new constant fields
    private const float MinAcceleration = 0.0f; 
    private const float MaxAcceleration = 100.0f;

    public Vector2 CurrentVelocity { get; private set; } = Vector2.Zero;
    private Vector2 Acceleration { get; set; } = Vector2.Zero;
    private float MaxSpeed { get; set; } = float.PositiveInfinity;

    public void SetAcceleration(float xAccel, float yAccel)
    {
        if (xAccel < MinAcceleration || xAccel > MaxAcceleration) 
        {
            throw new ArgumentOutOfRangeException(nameof(xAccel));
        }

        if (yAccel < MinAcceleration || yAccel > MaxAcceleration) 
        {
            throw new ArgumentOutOfRangeException(nameof(yAccel));
        }

        this.Acceleration = new Vector2(xAccel, yAccel);
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        this.MaxSpeed = maxSpeed;
    }

    public void UpdateVelocity(float deltaTime)
    {
        this.CurrentVelocity += this.Acceleration * deltaTime;

        var speed = this.CurrentVelocity.Length();

        if (speed > this.MaxSpeed)
        {
            var direction = Vector2.Normalize(this.CurrentVelocity);
            this.CurrentVelocity = direction * this.MaxSpeed;
        }
    }
}