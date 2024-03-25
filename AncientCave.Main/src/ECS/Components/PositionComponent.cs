namespace AncientCave.Main.ECS.Components;

public readonly struct PositionComponent
{
    public float X { get; }
    public float Y { get; }

    public PositionComponent(float x, float y)
    {
        X = x;
        Y = y;
    }
}