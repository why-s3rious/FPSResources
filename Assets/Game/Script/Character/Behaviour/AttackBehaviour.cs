using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackBehaviour : BaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        this.zombie.ApplyDamage(this.player);

    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
    {
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        base.OnStateUpdate(animator, stateinfo, layerindex);
        this.zombie.StopMovement();
        
    }
}
