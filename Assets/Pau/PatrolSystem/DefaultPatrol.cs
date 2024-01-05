using UnityEngine;

public class DefaultPatrol : IA_Behaviour
{
    [SerializeField]
    protected Transform[] patrolPoints;

    protected int destinyPoint = 0;
    public float patrolSpeed;

    public void PatrolType()
    {
        NMAgent.destination = patrolPoints[destinyPoint].position;
        destinyPoint = (destinyPoint + 1) % patrolPoints.Length;
    }
}
