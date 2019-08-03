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
            target.newHealth = target.health - (currentAttack.attackPower * currentAttacker.stats.spellPower / (target.stats.defense * target.defending));


            animator.SetTrigger("DealDamage");

        }

        if (currentAttack != null && currentAttack.isPhysical == true)
        {
            target.newHealth = target.health - (currentAttack.attackPower * currentAttacker.stats.strength / (target.stats.defense * target.defending));

            animator.SetTrigger("DealDamage");

        }

    }

}
