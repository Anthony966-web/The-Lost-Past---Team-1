using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public LayerMask attackLayer;
    public Transform GoblinHealth;
    public float attackDamage = 1f;

    public float damage = 1f;
    public GameObject AttackHitbox;
    Collider2D AttackCollider;

    private PlayerController topDown;

    
    void Start()
    {
        topDown = GetComponent<PlayerController>();
        print(topDown);
        AttackCollider = AttackHitbox.GetComponent<Collider2D>();
    }

    
    void Update()
    {

    }




    public void Attack(InputAction.CallbackContext ctx)
    {
        RaycastHit2D Onhit = Physics2D.CircleCast(transform.position + (Vector3)topDown.direction, attackRange, Vector2.zero, 0, attackLayer);

        if (Onhit)
        {
            if (Onhit.collider != null)
            {
                UnityEngine.Debug.Log("Hit " + Onhit.collider.name);

                if (Onhit.collider.gameObject.CompareTag("Enemy_"))
                {
                    GoblinHealth = Onhit.collider.transform;
                    GoblinHealth goblinHealth = GoblinHealth.GetComponent<GoblinHealth>();
                    

                }
            }
        }

        if (ctx.performed)
        {
            AttackCollider.enabled = true;


        }
        else
        {
            AttackCollider.enabled = false;
        }
    }




    private void OnDrawGizmos()
    {
        if (topDown != null)
        {
            Gizmos.DrawWireSphere(transform.position + (Vector3)topDown.direction, attackRange);
        }
    }


}
