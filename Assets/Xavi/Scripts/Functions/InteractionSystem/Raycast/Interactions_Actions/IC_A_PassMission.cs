using System;
using System.Collections.Generic;
using UnityEngine;

public class IC_A_PassMission : InteractionAction
{
    public List<MissionUpdate> mission;
    public List<MissionStepUpdate> missionStep;

    public Mission mision;

    public override void Act(GameObject other)
    {
        MissionSystem.Instance.UpdateStatusMission(mision, mission, missionStep);
        Destroy(this);
    }
}
