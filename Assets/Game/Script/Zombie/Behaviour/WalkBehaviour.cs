using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehaviour : BaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        base.OnStateUpdate(animator, stateinfo, layerindex);
        zombie.MoveToTarget(this.player);
    }

}
