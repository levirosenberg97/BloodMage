using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public TargetObject player;
    public Animator anim;

    public List<TargetObject> battleOrder;

    public TargetObject currentAttacker;

    private void Start()
    {
        battleOrder = new List<TargetObject>();

        TargetObject[] enemies = FindObjectsOfType<TargetObject>();

        for (int i = 0; i < enemies.Length; ++i)
        {
            if(enemies[i].GetComponent<TargetObject>() != null)
            {
                battleOrder.Add(enemies[i].GetComponent<TargetObject>());
            }
        }

        ReorderList();
    }

    void ReorderList()
    {
        battleOrder.Sort(delegate (TargetObject a, TargetObject b)
        {
            return (b.stats.speed).CompareTo(a.stats.speed);
        });
    }

    public void SetTarget(TargetObject target)
    {
        player.target = target;
        anim.SetBool("StartCombatOrder", true);
    }

    public void PhysicalAttack()
    {
        player.stats.currentAttack = player.stats.physicalAttack;
    }

    public void MagicAttack()
    {
        player.health -= player.stats.magicAttack.attackPower / 2;
        player.stats.currentAttack = player.stats.magicAttack;
    }
    
    public void DefendYourself()
    {
        Debug.Log("Defense");
    }

    public void EnemyAttack(TargetObject enemy)
    {
        player.health -= enemy.stats.strength;
        player.healthSlider.value = player.health;

        Debug.Log("Hit");
    }
}
