using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIntOnEnter : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Index", Random.Range(0,4));
    }

}
