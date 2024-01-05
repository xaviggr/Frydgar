using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    DefaultPatrol ia_movement;
    NavMeshAgent NMAgent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Declaramos 
        ia_movement = animator.gameObject.GetComponent<DefaultPatrol>();
        NMAgent = ia_movement.NMAgent;
        ///////////////////////////////

        ia_movement.PatrolType();
        NMAgent.speed = ia_movement.patrolSpeed;
        NMAgent.stoppingDistance = 0;
        animator.SetFloat("Speed", ia_movement.patrolSpeed);
        animator.SetBool("isPatrolling", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!NMAgent.pathPending && NMAgent.remainingDistance < 0.5f)
        {
            ia_movement.PatrolType();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPatrolling", false);
    }
}
