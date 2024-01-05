using UnityEngine;

public class IA_Anim_Controller : MonoBehaviour
{
    private void Dead()
    {
        GetComponent<Animator>().SetBool("Die", true);
    }

    private void Hurt()
    {
        GetComponent<Animator>().SetTrigger("Hurt");
    }

    private void OnEnable()
    {
        GetComponent<StatsSystem>().TriggerNohealth += Dead;
        GetComponent<StatsSystem>().TriggerHurt += Hurt;
    }

    private void OnDisable()
    {
        GetComponent<StatsSystem>().TriggerNohealth -= Dead;
        GetComponent<StatsSystem>().TriggerHurt -= Hurt;
    }
}
