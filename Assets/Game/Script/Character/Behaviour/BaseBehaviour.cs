using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : StateMachineBehaviour
{
    public Zombie zombie;
    public Transform player;


    public void Init(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Init Basebehaviour");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombie = animator.GetComponent<Zombie>();
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        float distant = Vector3.Distance(player.position, this.zombie.transform.position);
        animator.SetFloat("DistantPlayer", distant);
        this.zombie.CheckCanUseSpecial(distant);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }

}
