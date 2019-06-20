using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerScript player;
    public Animator anim;

    public List<PlayerStats> battleOrder;

    public PlayerStats currentAttacker;

    private void Start()
    {
        battleOrder = new List<PlayerStats>();

        battleOrder.Add(player.playerStats);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Damagable");

        for (int i = 0; i < enemies.Length; ++i)
        {
            if(enemies[i].GetComponent<EnemyStats>() != null)
            {
                battleOrder.Add(enemies[i].GetComponent<EnemyStats>().stats);
            }
        }

        ReorderList();
    }

    void ReorderList()
    {
        battleOrder.Sort(delegate (PlayerStats a, PlayerStats b)
        {
            return (b.speed).CompareTo(a.speed);
        });
    }

    public void SetTarget(GameObject target)
    {
        player.playerStats.target = target;
        anim.SetBool("StartCombatOrder", true);
    }

    public void PhysicalAttack(EnemyStats enemy)
    {
        enemy.health -= player.playerStats.strength + player.playerStats.physicalAttack.attackPower;
        enemy.healthSlider.value = enemy.health;

        anim.SetBool("IsAttacking", true);
    }

    public void MagicAttack(EnemyStats enemy)
    {
        enemy.health -= player.playerStats.spellPower + player.playerStats.magicAttack.attackPower;
        player.health -= (player.playerStats.spellPower + player.playerStats.magicAttack.attackPower) / 2;

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

        Debug.Log("Hit");
    }
}
