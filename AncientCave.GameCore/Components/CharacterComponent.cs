namespace AncientCave.GameCore.Components;

public class CharacterComponent
{
    public CharacterBaseComponent CharacterBase { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public StatsComponent LevelUpHistory { get; set; }
    public string Weapon { get; set; } //TODO
    public string Armor { get; set; } //TODO
    public string[] Rings { get; set; } //TODO
    public string Amulet { get; set; } //TODO
}