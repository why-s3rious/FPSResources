using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DeathBehaviour : BaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        this.zombie.StopMovement();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        //base.OnStateUpdate(animator, stateinfo, layerindex);
    }
}
