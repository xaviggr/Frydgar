using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    [TextArea(15, 20)]
    public string description;
    public Sprite spr;
    public GameObject model;
    public ItemType type;

    public abstract void Use();
}
