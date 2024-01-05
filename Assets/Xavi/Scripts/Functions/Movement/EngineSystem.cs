using UnityEngine;

public abstract class EngineSystem : MonoBehaviour
{
    public abstract void Move(Vector3 dir, float movementSpeed);
}
