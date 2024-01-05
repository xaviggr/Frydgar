using UnityEngine;

public class IC_Trigger : InteractionCollision
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.TryGetComponent(out InteractionReceiver IR))
        {
            IR.Receive(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.TryGetComponent(out InteractionReceiver IR))
        {
            IR.Out(this.gameObject);
        }
    }
}
