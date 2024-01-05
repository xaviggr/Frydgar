using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    private static MissionSystem _instance;
    public static MissionSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MissionSystem>();
            }
            return _instance;
        }
    }

    private void UpdateMission(Mission m, bool started)
    {
        if (!m.started) m.started = true;
    }

    private void UpdateMissionStep(Mission m, MissionStep ms, bool discovered, bool completed)
    {
        if (!ms.discovered) ms.discovered = true;
        if (!ms.completed) ms.completed = true;
        m.completed = CheckMission(m);
        if (m.completed) NotificationController.Instance.AddNotification("Has completado " + m._name, 5);
    }

    private bool CheckMission(Mission m)
    {
        bool completed = true;

        for (int i = 0; i < m.missionSteps.Count && completed; i++)
        {
            if(!m.missionSteps[i].completed)
            {
                completed = false;
            }
        }

        return completed;
    }

    public void UpdateStatusMission(Mission mision, List<MissionUpdate> mission, List<MissionStepUpdate> missionStep)
    {
        for (int i = 0; i < mission.Count; i++)
        {
            MissionSystem._instance.UpdateMission(mission[i].mission, mission[i].started);
            NotificationController.Instance.AddNotification("Misión '" + mission[i].mission.name + "' ha sido actualizada.", 5);
        }
        for (int i = 0; i < missionStep.Count; i++)
        {
            MissionSystem._instance.UpdateMissionStep(mision, missionStep[i].missionStep, missionStep[i].discovered, missionStep[i].completed);
            NotificationController.Instance.AddNotification("'" + missionStep[i].missionStep.desc + "' se ha actualizado.", 5);
        }
    }
}
