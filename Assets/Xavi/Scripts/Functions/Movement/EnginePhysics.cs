using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnginePhysics : EngineSystem
{
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 dir, float movementSpeed)
    {
        dir.Normalize();
        rb.velocity = (dir * movementSpeed * Time.deltaTime);
    }
}
