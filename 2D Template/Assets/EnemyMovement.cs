using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //  https://www.youtube.com/watch?v=IEadGWvewsA

    public float speed;
    public float chaseRange = 5f;
    public float attackRange = 2f;
    private int facingDirection = -1;
    private EnemyState enemyState;

    private Rigidbody2D rb2D;
    public Transform player;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            ChangeState(EnemyState.Chasing);
        }
        else
        {
            ChangeState(EnemyState.Chasing);
        }

        if (enemyState == EnemyState.Chasing)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
            {
                ChangeState(EnemyState.Attacking);
            }

            else if(player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb2D.linearVelocity = direction * speed;
        }
        else
        {
            rb2D.linearVelocity = Vector2.zero;
        }

        if (enemyState == EnemyState.Attacking)
        {
            rb2D.linearVelocity = Vector2.zero;
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}