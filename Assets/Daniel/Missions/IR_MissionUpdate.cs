using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MissionUpdate
{
    public Mission mission;
    public bool started;
}

[Serializable]
public class MissionStepUpdate
{
    public MissionStep missionStep;
    public bool discovered;
    public bool completed;
}

public class IR_MissionUpdate : InteractionReceiver
{
    public List<MissionUpdate> mission;
    public List<MissionStepUpdate> missionStep;

    public Mission mision;

    public override void Receive(GameObject other)
    {
        MissionSystem.Instance.UpdateStatusMission(mision, mission, missionStep);
        this.gameObject.SetActive(false);
    }

    public override void Out(GameObject other)
    {

    }
}
