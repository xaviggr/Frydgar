using UnityEngine;

public abstract class InteractionReceiver : MonoBehaviour
{
    public abstract void Receive(GameObject other);
    public abstract void Out(GameObject other);
}
