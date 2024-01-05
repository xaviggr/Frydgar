using UnityEngine;
using System;

public class IC_A_TeleportTo : InteractionAction
{
    public Transform pos;

    public override void Act(GameObject other)
    {
        MapLocationController.Instance.GoToPos(pos.position,0.5f);
    }
}
