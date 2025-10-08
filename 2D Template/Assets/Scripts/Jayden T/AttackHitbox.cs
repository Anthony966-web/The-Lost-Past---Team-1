using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Collider2D AttackCollider;
    public float attackDamage = 1f;
    private PlayerNormalAttack playerNormalAttack;
    public Vector3 faceRight = new Vector3(1, -0.9f, 0);
    public Vector3 faceLeft = new Vector3(-1, -0.9f, 0);


    void Start()
    {
        if (AttackCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player hit " + collision.name);
        collision.SendMessage("OnHit", attackDamage);

        Debug.Log("Hit");
    }

    public void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.position = faceRight;
        }
        else
        {
            gameObject.transform.position = faceLeft;
        }
    }
}
