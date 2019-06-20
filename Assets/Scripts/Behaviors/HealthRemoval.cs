using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRemoval : StateMachineBehaviour
{    
    int counter;
    public float timer;
    float maxTimer;
    PlayerCombat combatManager;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maxTimer = timer;
        counter++;
        combatManager = FindObjectOfType<PlayerCombat>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if(combatManager.battleOrder[counter - 1])
            animator.SetBool("EnemyAttacking", true);
        }
    }

    
}
