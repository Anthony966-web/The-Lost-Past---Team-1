using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField]public float attackRange = 1.5f;
    [SerializeField]public LayerMask attackLayer;

    private PlayerController topDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topDown = GetComponent<PlayerController>();
        print(topDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + (Vector3)topDown.direction, attackRange, Vector2.zero, 0, attackLayer);

       if (hit)
            {
                UnityEngine.Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject, 0);
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
