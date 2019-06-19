using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRemoval : StateMachineBehaviour
{
    [SerializeField]
    int counter;
    public float timer;
    float maxTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maxTimer = timer;
        counter++;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {

        }
    }

    
}
