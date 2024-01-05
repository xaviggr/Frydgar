using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    Attack ia_attack;
    NavMeshAgent NMAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Declaramos 
        ia_attack = animator.gameObject.GetComponent<Attack>();
        NMAgent = ia_attack.NMAgent;
        //////////////////////

        ia_attack.gun_collider.enabled = true;
        NMAgent.speed = 0;
        animator.SetFloat("Speed", 0);
        animator.SetBool("Attack", true);
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ia_attack.gun_collider.enabled = false;
        animator.SetBool("Attack", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}