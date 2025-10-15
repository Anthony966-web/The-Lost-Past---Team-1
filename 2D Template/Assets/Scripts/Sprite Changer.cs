using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer Spite;

    public GameObject COV;

    public Sprite CS;

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
