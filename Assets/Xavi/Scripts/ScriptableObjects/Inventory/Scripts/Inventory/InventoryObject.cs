using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    [SerializeField] int MaxSlotsInventory;

    public List<InventorySlot> Container = new List<InventorySlot>();

    public bool RemoveItem(ItemObject _item, int _amount)
    {
        bool HasBeenRemoved = true;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].amount -= _amount;
                if (Container[i].amount <= 0)
                {
                    Container.Remove(Container[i]);
                }
                break;
            }
        }

        return HasBeenRemoved;
    }

    public bool AddItem(ItemObject _item, int _amount)
    {
        bool HasBeenAdded = true;

        bool hasitem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].amount += _amount;
                hasitem = true;
                break;
            }
        }

        if (Container.Count >= MaxSlotsInventory && !hasitem)
        {
            HasBeenAdded = false;

        }
        else if (!hasitem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }

        return HasBeenAdded;
    }

    public InventorySlot GetItem(ItemObject _item)
    {
        InventorySlot item = null;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                item = Container[i];
                break;
            }
        }

        return item;
    }
}