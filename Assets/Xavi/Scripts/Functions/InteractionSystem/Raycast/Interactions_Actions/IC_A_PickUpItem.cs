using UnityEngine;

public class IC_A_PickUpItem : InteractionAction
{
    public int amount = 0;
    public ItemObject item;
    public GameObject message;

    public override void Act(GameObject other)
    {
        InventoryController.Instance.player_inventory.AddItem(item, amount);
        NotificationController.Instance.AddNotification("Has obtenido x" + amount + " " + item.name, 5);
        message.SetActive(false);
    }
}
