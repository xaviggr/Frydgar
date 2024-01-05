using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassMission : MonoBehaviour
{
    public List<MissionUpdate> mission;
    public List<MissionStepUpdate> missionStep;

    public Mission mision;

    private void Pass()
    {
        MissionSystem.Instance.UpdateStatusMission(mision, mission, missionStep);
    }

    private void OnEnable()
    {
        GetComponent<StatsSystem>().TriggerNohealth += Pass;
    }

    private void OnDisable()
    {
        GetComponent<StatsSystem>().TriggerNohealth -= Pass;
    }
}
