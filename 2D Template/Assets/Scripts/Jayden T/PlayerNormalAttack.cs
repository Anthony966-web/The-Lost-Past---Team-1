using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public LayerMask attackLayer;
    public Transform EnemyHealth;
    

    public float damage = 1f;
    public GameObject AttackHitbox;
    

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
                EnemyHealth = Onhit.collider.transform;
                EnemyHealth enemyHealth = EnemyHealth.GetComponent<EnemyHealth>();
                EnemyHealth.SendMessage("OnHit", damage);
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
