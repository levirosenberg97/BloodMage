using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAttack : StateMachineBehaviour
{
    [SerializeField]
    PlayerCombat combatManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {    
        combatManager = FindObjectOfType<PlayerCombat>();

        Attacks currentAttack = combatManager.currentAttacker.stats.currentAttack;
        TargetObject currentAttacker = combatManager.currentAttacker;
        TargetObject target = currentAttacker.target;

        if(currentAttack.isMagic == true)
        {
            target.health -= (currentAttack.attackPower + ( currentAttacker.stats.spellPower - target.stats.defense));
        }

        if (currentAttack.isPhysical == true)
        {
            target.health -= (currentAttack.attackPower + (currentAttacker.stats.strength - target.stats.defense));
        }

        animator.SetTrigger("DealDamage");
    }

}
