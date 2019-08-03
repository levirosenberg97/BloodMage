using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : StateMachineBehaviour
{
    PlayerCombat combatManager;
    TargetObject target;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        combatManager = FindObjectOfType<PlayerCombat>();
        target = combatManager.currentAttacker.target;
        Debug.Log("Dead");
        combatManager.battleOrder.Remove(target);

        if(target.stats.type == PlayerStats.PlayerType.Player)
        {
            target.gameObject.SetActive(false);
        }
        else
        {
            target.gameObject.SetActive(false);
        }


        animator.SetTrigger("CheckTurnManager");
    }
}
