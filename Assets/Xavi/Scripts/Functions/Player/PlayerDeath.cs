using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void Die()
    {
        StarterAssets.AnimController.Instance.AnimPlayDie();
        InventoryController.Instance.player_inventory.Container.Clear();
    }

    private void OnEnable()
    {
        GetComponent<StatsSystem>().TriggerNohealth += Die;
    }

    private void OnDisable()
    {
        GetComponent<StatsSystem>().TriggerNohealth -= Die;
    }
}
