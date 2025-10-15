using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer Spite;

    public GameObject COV;

    public Sprite CS;

    public Item[] itemsToPickup;

    public InventoryManager inventoryManager;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Item Not Added");
        }
    }

    void Awake()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();

        Spite = GetComponent<SpriteRenderer>();
        COV = gameObject;
        CS = Resources.Load<Sprite>("Golem-Cloth_1");
    }

    public void Clothed()
    {
        Spite.sprite = CS;
        COV.SetActive(true);
    }
}
