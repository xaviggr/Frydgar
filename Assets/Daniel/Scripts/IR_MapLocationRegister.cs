using UnityEngine;

public class IR_MapLocationRegister : InteractionReceiver
{
    public string locationName;
    public bool discovered;

    public override void Receive(GameObject other)
    {
        MapLocationController.Instance.DiscoverLocation(locationName, discovered);
    }

    public override void Out(GameObject other)
    {

    }

}
