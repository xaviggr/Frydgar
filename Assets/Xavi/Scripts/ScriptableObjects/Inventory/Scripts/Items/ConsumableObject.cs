using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemObject
{
    public int value;
    public void Awake()
    {
        type = ItemType.Consumable;
    }

    public override void Use()
    {
        StatsPlayerController.Instance.player_stats.AddHealth(value);
    }
}
