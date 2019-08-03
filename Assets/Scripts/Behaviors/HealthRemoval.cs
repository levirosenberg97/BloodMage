using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRemoval : StateMachineBehaviour
{    
    int counter;
    public float timer;
    float maxTimer;
    PlayerCombat combatManager;
    TargetObject currentAttacker;
    TargetObject target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maxTimer = timer;
        counter++;
        combatManager = FindObjectOfType<PlayerCombat>();

        currentAttacker = combatManager.currentAttacker;
        target = currentAttacker.target;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(target.health > target.newHealth)
        {
            target.health--;
            target.healthSlider.value = target.health;
        }
        else
        {
            if (target.health <= 0)
            {
                target.health = target.newHealth;
                target.healthSlider.value = target.health;
                animator.SetTrigger("isDead");
            }
            else
            {
                animator.SetTrigger("CheckTurnManager");
            }
        }
    }    
}
