using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Collider2D AttackCollider;
    public float attackDamage = 1f;

    void Start()
    {
        if (AttackCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }

    }

    void OnColllisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", attackDamage);
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("OnHit", attackDamage);
    }
}
