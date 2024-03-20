namespace AncientCave.Components;

public class HealthComponent
{
    private int CurrentHealth { get; set; }
    private int MaxHealth { get; set; }

    public HealthComponent(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

    public void Heal(int healingAmount)
    {
        CurrentHealth += healingAmount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }

    public bool IsAlive()
    {
        return CurrentHealth > 0;
    }
}