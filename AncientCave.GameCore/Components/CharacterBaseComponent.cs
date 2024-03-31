namespace AncientCave.GameCore.Components;

public class CharacterBaseComponent
{
    public string DescriptionKey { get; set; }
    public string ClassNameKey { get; set; }
    public StatsComponent BaseStats { get; set; }
    public List<string> Weapons { get; set; }
    public List<string> ArmorClasses { get; set; }
    public string SpellLevel { get; set; }
    public List<string> SpellClasses { get; set; }
    public string PathSpritesheetWalking { get; set; }
    public string PathSpritesheetAttacking { get; set; }
}