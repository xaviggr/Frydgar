using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSys", menuName = "MissionSys/Mission", order = 1)]
public class Mission : ScriptableObject
{
    public string _name;

    [TextArea(15, 20)]
    public string desc;

    public bool started;//se considera completada una Mision cuando
    public bool completed;//todos sus Pasos han sido Completados



    public List<MissionStep> missionSteps;

}
