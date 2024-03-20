namespace AncientCave.Entities;

public class ItemEntity
{
    public string Name { get; set; }
    public int Value { get; set; }

    public ItemEntity(string name, int value)
    {
        Name = name;
        Value = value;
    }
}