using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [Header("UI")]
    public Image image;
    public TMP_Text countText;

    public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (InventoryManager.instance.mainInventory.activeSelf && eventData.button == PointerEventData.InputButton.Right)
        {
            int currentIndex = -1;
            for (int i = 0; i < InventoryManager.instance.InventorySlots.Length; i++)
            {
                if (transform.parent == InventoryManager.instance.InventorySlots[i].transform)
                {
                    currentIndex = i;
                    break;
                }
            }

            if (currentIndex == -1) return;

            int hotbarSize = 7;
            int targetIndex = -1;

            if (currentIndex < hotbarSize)
            {
                for (int i = hotbarSize; i < InventoryManager.instance.InventorySlots.Length; i++)
                {
                    if (InventoryManager.instance.InventorySlots[i].transform.childCount == 0)
                    {
                        targetIndex = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < hotbarSize; i++)
                {
                    if (InventoryManager.instance.InventorySlots[i].transform.childCount == 0)
                    {
                        targetIndex = i;
                        break;
                    }
                }
            }

            if (targetIndex != -1)
            {
                Transform targetSlot = InventoryManager.instance.InventorySlots[targetIndex].transform;
                transform.SetParent(targetSlot);
                transform.localPosition = Vector3.zero;
                parentAfterDrag = targetSlot;
            }
            else
            {
                Debug.Log("No available slot to move to!");
            }
        }
    }
}
