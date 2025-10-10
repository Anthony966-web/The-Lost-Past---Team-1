using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item[] startItems;

    public int maxStackedItems = 4;
    public InventorySlot[] InventorySlots;
    public InventoryEquipmentSlot[] EquipSlots;

    public GameObject mainInventory;

    public GameObject inventoryItemPrefab;

    [HideInInspector] public int selectedSlot = -1;

    private float zero = 0;
    private float one = 0;
    private float two = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var item in startItems)
        {
            AddItem(item);
        }
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }
        }

    }

    private void FixedUpdate()
    {
        for(int i = 0; i < EquipSlots.Length; i++)
        {
            if (i == 0)
            {
                zero = EquipSlots[0].speedBoost;
            }

            if (i == 1)
            {
                one = EquipSlots[1].speedBoost;
            }

            if (i == 2)
            {
                two = EquipSlots[2].speedBoost;
            }

            if (EquipSlots[i].transform.childCount != 1)
            {
                if (i == 0)
                {
                    zero = 0;
                }
                if (i == 1)
                {
                    one = 0;
                }
                if (i == 2)
                {
                    two = 0;
                }
            }
            
        }

        PlayerController.instance.speedMultiplier = zero + one + two;
}

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            InventorySlots[selectedSlot].Deselect();
        }

        print(selectedSlot.ToString());
        print(newValue.ToString());
        if (selectedSlot == newValue)
        {
            InventorySlots[selectedSlot].Deselect();
            selectedSlot = -1;
            return;
        }
        InventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {

        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = InventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;

                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }

        return null;
    }
}
