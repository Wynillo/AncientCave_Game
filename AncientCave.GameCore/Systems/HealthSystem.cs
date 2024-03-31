// HealthSystem.cs

using AncientCave.GameCore.Entities;

namespace AncientCave.GameCore.Systems;

public class HealthSystem
{
    public void ApplyDamage(EnemyEntity enemy, int damage)
    {
        enemy.Health -= damage;

        if (enemy.Health <= 0)
        {
            // Handle enemy death
        }
    }

    public void HealPlayer(PlayerEntity player, int amount)
    {
        player.Health += amount;

        // Prevent overhealing
        player.Health = Math.Min(100, player.Health);
    }
}