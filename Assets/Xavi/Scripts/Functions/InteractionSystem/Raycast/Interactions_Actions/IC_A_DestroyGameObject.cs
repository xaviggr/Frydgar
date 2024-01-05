using UnityEngine;

public class IC_A_DestroyGameObject : InteractionAction
{
    public override void Act(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
