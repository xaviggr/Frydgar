using UnityEngine;

public class StatsPlayerController : MonoBehaviour
{
    public StatsSystem player_stats;

    private static StatsPlayerController _instance;
    public static StatsPlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StatsPlayerController>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        player_stats = this.GetComponent<StatsSystem>();
    }
}
