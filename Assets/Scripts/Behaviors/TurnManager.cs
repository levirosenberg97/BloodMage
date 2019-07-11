using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : StateMachineBehaviour
{
    public int counter;
    PlayerCombat combatManager;

    [SerializeField]
    List<TargetObject> players;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(combatManager == null)
        {
            combatManager = FindObjectOfType<PlayerCombat>();
        }
        
        //players = new List<TargetObject>();
        players = combatManager.battleOrder;  
        counter++;


        if (counter > players.Count)
        {
            counter = 0;
            foreach (TargetObject player in players)
            {
                player.defending = 1;
            }
            animator.SetBool("StartCombatOrder", false);
        }
        else
        {
            combatManager.currentAttacker = players[counter - 1];

            animator.SetTrigger("NextAttack");
        }
    }
}
