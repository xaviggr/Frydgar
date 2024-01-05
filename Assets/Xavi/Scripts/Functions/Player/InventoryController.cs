using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventoryObject player_inventory;

    private static InventoryController _instance;
    public static InventoryController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryController>();
            }
            return _instance;
        }
    }
}