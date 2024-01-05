using UnityEngine;

public class Pursuit : IA_Behaviour
{
    public float pursuitSpeed;
    public Transform target;

    public void PursuitAction()
    {
        NMAgent.destination = target.position;
    }

    public float CheckDistanceToEnemy()
    {
        return NMAgent.remainingDistance;
    }
}
