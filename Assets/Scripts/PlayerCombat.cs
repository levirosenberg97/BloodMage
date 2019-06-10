using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats player;

    public void PhysicalAttack()
    {
        EnemyStats enemy = player.target;

        enemy.health -= player.strength;
    }

    public void MagicAttack()
    {
        EnemyStats enemy = player.target;

        enemy.health  -= player.spellPower;
        player.health -= player.spellPower / 2;

        enemy.healthSlider.value  = enemy.health;
        player.healthSlider.value = player.health;
    }

    public void DefendYourself()
    {
        EnemyStats enemy = player.target;
    }

    void MakeTargetable()
    {
        var enemies = FindObjectsOfType<EnemyStats>();
        foreach (EnemyStats enemy in enemies)
        {
            enemy.selectable = true;
        }
    }
}
