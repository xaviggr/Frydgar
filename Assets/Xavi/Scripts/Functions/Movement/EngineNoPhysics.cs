using UnityEngine;

public class EngineNoPhysics : EngineSystem
{
    public override void Move(Vector3 dir, float movementSpeed)
    {
        transform.position += dir * movementSpeed * Time.deltaTime;
    }
}
