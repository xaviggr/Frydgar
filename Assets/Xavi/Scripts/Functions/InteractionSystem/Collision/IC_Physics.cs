using UnityEngine;

public class IC_Physics : InteractionCollision
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out InteractionReceiver IR))
        {
            IR.Receive(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out InteractionReceiver IR))
        {
            IR.Out(this.gameObject);
        }
    }
}
