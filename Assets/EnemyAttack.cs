using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    PlayerCombat combatManager;
    EnemyStats[] enemies;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        combatManager = FindObjectOfType<PlayerCombat>();
        enemies = FindObjectsOfType<EnemyStats>();

        foreach(EnemyStats enemy in enemies)
        {
            combatManager.EnemyAttack(enemy);
        }
        animator.SetBool("IsAttacking", false);
    }
    
    IEnumerator WaitForSeconds(float sec)
    {
        yield return null;
    }
}
