using UnityEngine;

public class IR_ChangeHealth : InteractionReceiver
{
    [SerializeField] float damage;

    public override void Receive(GameObject other)
    {
        if (other.TryGetComponent(out StatsSystem stats))
        {
            stats.TakeDamage(damage);
        }
    }

    public override void Out(GameObject other)
    {

    }
}
