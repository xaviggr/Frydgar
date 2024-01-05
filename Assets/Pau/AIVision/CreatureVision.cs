using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureVision : IC_Trigger
{
    public List<GameObject> Detections = new List<GameObject>();

    public event Action<GameObject> AddTarget;
    public event Action<GameObject> RemoveTarget;

    private void OnTriggerEnter(Collider other)
    {
        Detections.Add(other.gameObject);
        AddTarget(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        Detections.Remove(other.gameObject);
        RemoveTarget(other.gameObject);
    }
}
