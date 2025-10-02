using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryEquipmentSlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    public EquipSlotType type;

    void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (Equip(type, droppedItem) == true)
        {
            if (transform.childCount == 0)
            {
                droppedItem.parentAfterDrag = transform;
            }
            else
            {
                Transform existingItem = transform.GetChild(0);
                InventorySlot oldSlot = droppedItem.parentAfterDrag.GetComponent<InventorySlot>();

                existingItem.SetParent(oldSlot.transform);
                existingItem.localPosition = Vector3.zero;

                droppedItem.parentAfterDrag = transform;
            }
        }
        else
        {
            Transform existingItem = transform.GetChild(0);
            InventorySlot oldSlot = droppedItem.parentAfterDrag.GetComponent<InventorySlot>();

            existingItem.SetParent(oldSlot.transform);
            existingItem.localPosition = Vector3.zero;

            droppedItem.parentAfterDrag = transform;
        }
    }

    public bool Equip(EquipSlotType slotType, InventoryItem item)
    {
        if (slotType == EquipSlotType.Head && item.item.itemClass == ItemTypeClass.Head)
        {
            return true;
        }
        else if (slotType == EquipSlotType.Chest && item.item.itemClass == ItemTypeClass.Chest)
        {
            return true;
        }
        else if (slotType == EquipSlotType.Legs && item.item.itemClass == ItemTypeClass.Legs)
        {
            return true;
        }

        return false;
    }
}

public enum EquipSlotType
{
    Head,
    Chest,
    Legs
}
