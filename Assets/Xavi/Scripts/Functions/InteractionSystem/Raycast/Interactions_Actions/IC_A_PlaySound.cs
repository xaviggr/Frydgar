using UnityEngine;
using System;

public class IC_A_PlaySound : InteractionAction
{
    public String sound;

    public override void Act(GameObject other)
    {
        SoundController.Instance.PlaySound(sound);
    }
}
