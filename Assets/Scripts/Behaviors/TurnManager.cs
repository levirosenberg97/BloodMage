using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : StateMachineBehaviour
{
    public int counter;
    PlayerCombat combatManager;

    [SerializeField]
    List<PlayerStats> players;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(combatManager == null)
        {
            combatManager = FindObjectOfType<PlayerCombat>();
        }
        
        players = new List<PlayerStats>();
        players = combatManager.battleOrder;  
        counter++;

        if(counter > players.Count)
        {
            counter = 0;
            animator.SetBool("StartCombatOrder", false);
        }

        combatManager.currentAttacker = players[counter - 1];

        animator.SetTrigger("NextAttack");
    }
}
