using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{

    [Header("Gameplay")]
    public TileBase Tile;
    public ItemType type;
    public ActionType actionType;
    public ItemTypeClass itemClass;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Equipment")]
    public float healthBoost;
    public float speedBoost;


    [Header("UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
    public GameObject itemObject;

    public void Awake()
    {
        if (type == ItemType.Equipable)
        {
            stackable = false;
        }
        else
        {
            itemClass = ItemTypeClass.Item;
        }
    }

}

public enum ItemType
{
    Equipable,
    Consumable,
    QuestItem
}

public enum ItemTypeClass
{
    Item,
    Head,
    Chest,
    Legs
}

public enum ActionType
{
    Equip,
    Consume,
    GiveQuestItem
}