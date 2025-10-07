using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public LayerMask attackLayer;
    public Transform GoblinHealth;

    public float damage = 1f;

    private PlayerController topDown;

    
    void Start()
    {
        topDown = GetComponent<PlayerController>();
        print(topDown);
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

                if (Onhit.collider.gameObject.CompareTag("Goblin_"))
                {
                    GoblinHealth = Onhit.collider.transform;
                    GoblinHealth goblinHealth = GoblinHealth.GetComponent<GoblinHealth>();
                    

                }
            }
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
