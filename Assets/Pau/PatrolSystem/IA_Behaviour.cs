using UnityEngine;
using UnityEngine.AI;

public abstract class IA_Behaviour : MonoBehaviour
{
    protected NavMeshAgent nMAgent;
    public NavMeshAgent NMAgent { get => nMAgent; set => nMAgent = value; }

    public virtual void Awake()
    {
        NMAgent = GetComponent<NavMeshAgent>();
    }
}
