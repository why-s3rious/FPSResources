using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieOld : Person
{
    //public Animator animator;
    //public Waypoint waypoint;
    [SerializeField]
    public int distantToFollow = 5;
    [SerializeField]
    private NavMeshAgent agent;
    public StateMachineBehaviour currentStateMachine;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {

        this.Init(10f, this.GetComponent<Animator>());
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //SearchPlayer();
    }

    private void SearchPlayer()
    {
        float distant = Vector3.Distance(player.position, this.transform.position);
        this.animator.SetFloat("DistantPlayer", distant);
    }

    private void WalkToWalkPlayer()
    {

    }

    public void MoveToTarget(Transform target)
    {
        agent.Resume();
        agent.SetDestination(target.position);
    }

    public void StopMovement()
    {
        agent.Stop();
    }
}
