using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats player;
    public Animator anim;

    public void PhysicalAttack(EnemyStats enemy)
    {
        //anim.SetBool("IsTargeted", true);
        enemy.health -= player.strength;
        enemy.healthSlider.value = enemy.health;
    }

    public void MagicAttack(EnemyStats enemy)
    {
        enemy.health -= player.spellPower;
        player.health -= player.spellPower / 2;

        enemy.healthSlider.value = enemy.health;
        player.healthSlider.value = player.health;
    }

    public void DefendYourself()
    {
        Debug.Log("Defense");
    }
}
