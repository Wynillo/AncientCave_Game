namespace AncientCave.Main.ECS.Entities;

public class ItemEntity : Entity
{
    public string Name { get; set; }
    public int Value { get; set; }

    public ItemEntity(string name, int value)
    {
        Name = name;
        Value = value;
    }
}