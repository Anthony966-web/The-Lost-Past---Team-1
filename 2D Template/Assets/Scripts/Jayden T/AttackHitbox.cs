using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHitbox : MonoBehaviour
{
//    public Collider2D AttackCollider;
//    public float attackDamage = 1f;
//    private PlayerNormalAttack playerNormalAttack;
//    public Vector3 faceRight = new Vector3(1, -0.9f, 0);
//    public Vector3 faceLeft = new Vector3(-1, -0.9f, 0);

//    public bool justAttcked = false;


//    void Start()
//    {
//        if (AttackCollider == null)
//        {
//            Debug.LogWarning("Sword Collider not set");
//        }

//    }

//    public void Attack(InputAction.CallbackContext ctx)
//    {
//        print(ctx);
//        if (ctx.performed)
//        {
//            AttackCollider.enabled = true;
//            justAttcked = false;
//        }
//        else
//        {
//            AttackCollider.enabled = false;
//        }
//    }
//    private void OnTriggerStay2D(Collider2D collision)
//    {
//       if (justAttcked == false)
//        {
//            Debug.Log("Player hit " + collision.gameObject.name);
//            collision.gameObject.SendMessage("OnHit", attackDamage);

//            Debug.Log("Hit");
//            justAttcked = true;
//        }
//    }

    
}
