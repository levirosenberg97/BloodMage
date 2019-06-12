using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerScript player;
    public Animator anim;

    public void PhysicalAttack(EnemyStats enemy)
    {
        //anim.SetBool("IsTargeted", true);
        enemy.health -= player.playerStats.strength;
        enemy.healthSlider.value = enemy.health;

        anim.SetBool("IsAttacking", true);
    }

    public void MagicAttack(EnemyStats enemy)
    {
        enemy.health -= player.playerStats.spellPower;
        player.health -= player.playerStats.spellPower / 2;

        enemy.healthSlider.value = enemy.health;
        player.healthSlider.value = player.health;

        anim.SetBool("IsAttacking", true);
    }

    public void DefendYourself()
    {
        Debug.Log("Defense");
    }

    public void EnemyAttack(EnemyStats enemy)
    {
        player.health -= enemy.stats.strength;
        player.healthSlider.value = player.health;
    }
}
