using System;
using UnityEngine;

public abstract class InteractionRaycast : MonoBehaviour
{
    public float distance;
    public LayerMask layermask;
    public event Action<float> RaycastActivated = delegate { };
}
