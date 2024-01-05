using UnityEngine;

[CreateAssetMenu(fileName = "MissionSys", menuName = "MissionSys/MissionStep", order = 1)]
public class MissionStep : ScriptableObject
{
    public string desc;
    public bool discovered;
    public bool completed;
}
