using UnityEngine;
using UnityEngine.AI;

public abstract class IA_Movement : MonoBehaviour
{
    protected NavMeshAgent nMAgent;
    public NavMeshAgent NMAgent { get => nMAgent; set => nMAgent = value; }

    public virtual void Awake()
    {
        NMAgent = GetComponent<NavMeshAgent>();
    }
}
