using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer Spite;

    void Awake()
    {
        Spite = GameObject.Find("GNX").GetComponent<SpriteRenderer>();
        GameObject.Find("Cloth overworld_0");
    }

    public void Clothed()
    {
        Spite.sprite = Resources.Load<Sprite>("Golem-Cloth_1");
    }
}
