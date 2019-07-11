using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAttack : StateMachineBehaviour
{ 
    PlayerCombat combatManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {    
        combatManager = FindObjectOfType<PlayerCombat>();

        Attacks currentAttack = combatManager.currentAttacker.stats.currentAttack;
        TargetObject currentAttacker = combatManager.currentAttacker;
        TargetObject target = currentAttacker.target;

        if(currentAttacker.defending > 1)
        {
            currentAttacker.stats.currentAttack = null;
            animator.SetTrigger("isDefending");
        }

        if (currentAttack != null && currentAttack.isMagic == true)
        {
            target.health -= (currentAttack.attackPower * currentAttacker.stats.spellPower / (target.stats.defense * target.defending));
            target.healthSlider.value = target.health;

            if (target.stats.type.Equals(PlayerStats.PlayerType.Player) && target.health <= 0)
            {
                animator.SetTrigger("isDead");
            }
            //else if(target.health <= 0)
            //{
                
            //}
            else
            {
                animator.SetTrigger("DealDamage");
            }
        }

        if (currentAttack != null && currentAttack.isPhysical == true)
        {
            target.health -= (currentAttack.attackPower * currentAttacker.stats.strength / (target.stats.defense * target.defending));
            target.healthSlider.value = target.health;

            if (target.stats.type.Equals(PlayerStats.PlayerType.Player) && target.health <= 0)
            {
                animator.SetTrigger("isDead");
            }
            //else if(target.health <= 0)
            //{

            //}
            else
            {
                animator.SetTrigger("DealDamage");
            }
        }

    }

}
