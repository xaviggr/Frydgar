using UnityEngine;

public class IR_UpdateMusClip : InteractionReceiver
{
    public string trackName;

    public override void Receive(GameObject other)
    {
        SoundController.Instance.PlaySound(trackName);
    }

    public override void Out(GameObject other)
    {

    }

}
