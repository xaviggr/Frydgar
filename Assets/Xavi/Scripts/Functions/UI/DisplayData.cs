using UnityEngine;

public abstract class DisplayData : MonoBehaviour
{
    public abstract void UpdateValue(float newvalue);
    public abstract void UpdateValue(string newvalue);
    public abstract void UpdateValue(int newvalue);
}
