[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    //Constructor
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void Addamount(int value)
    {
        amount += value;
    }
}