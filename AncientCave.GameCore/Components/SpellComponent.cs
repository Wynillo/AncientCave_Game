namespace AncientCave.GameCore.Components;


public class SpellComponent
{
    public enum SpellEffectTypes
    {
        Damage,
        Damage_Over_Time,
        Full_Restoration,
        HP_Restoration,
        MP_Restoration,
        Revival,
        Status_Ailment,
        Status_Ailment_Cure
    }

    public enum Targets
    {
        Single,
        Group
    }

    public enum Ailments
    {
        Paralysis,
        Poison,
        Silence,
        Sleep
    }

public SpellEffectTypes SpellEffect { get; set; }
    public Targets SpellTarget { get; set; }
    
}