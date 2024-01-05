using UnityEngine;
using UnityEngine.AI;

public class PursuitState : StateMachineBehaviour
{
    public float distance_to_attack = 1f;

    Pursuit ia_movement;
    NavMeshAgent NMAgent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Declaramos 
        ia_movement = animator.gameObject.GetComponent<Pursuit>();
        NMAgent = ia_movement.NMAgent;
        ///////////////////////////////

        NMAgent.stoppingDistance = 1.6f;
        NMAgent.speed = ia_movement.pursuitSpeed;
        animator.SetFloat("Speed", ia_movement.pursuitSpeed);
        animator.SetBool("isPursuiting", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ia_movement.PursuitAction();

        if (ia_movement.CheckDistanceToEnemy() < distance_to_attack)
        {
            animator.SetBool("Attack", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPursuiting", false);
    }
}
