using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

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
}
