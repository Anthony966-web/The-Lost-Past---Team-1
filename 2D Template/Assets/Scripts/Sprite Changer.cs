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
        Spite = GameObject.Find("GNX").GetComponent<SpriteRenderer>();
        GameObject.Find("Cloth overworld_0");
        COV = GameObject.Find("ClothOverWorld");
        CS = Resources.Load<Sprite>("Golem-Cloth_1");
    }

    public void Clothed()
    {
        Spite.sprite = CS;
        COV.SetActive(false);
    }
}
