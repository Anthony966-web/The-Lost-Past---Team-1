using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Vector2 _movement;
    private float movementSpeed;
    public float speedMultiplier;
    public float baseMoveSpeed;
    public bool canceled;

    public Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public GameObject GFX;
    [HideInInspector] public Animator anim;


    [Header("Attack Settings")]
    public float damage = 25f;
    public float maxDistance = 100f;
    public LayerMask enemyLayer;
    public float splashRadius = 1.5f;

    [Header("References")]
    public Camera cam;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        GFX = transform.Find("GFX").transform.gameObject;
        anim = GFX.GetComponent<Animator>();
        direction = Vector2.down;
    }

    void Update()
    {
        anim.SetFloat("Horizontal", _movement.x);
        anim.SetFloat("Vertical", _movement.y);

        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        anim.SetBool("isWalking", true);
        _movement = ctx.ReadValue<Vector2>();

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
        }

        canceled = ctx.canceled;

        if (canceled == false)
        {
            anim.SetFloat("LastInputX", _movement.x);
            anim.SetFloat("LastInputY", _movement.y);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }
    }

    private void FixedUpdate()
    {
        movementSpeed = baseMoveSpeed + speedMultiplier;
        rb2D.linearVelocity = new Vector2(_movement.x * movementSpeed, _movement.y * movementSpeed);
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        anim.SetBool("Attack", true);

        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogWarning("No camera assigned!");
                return;
            }
        }

        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;

        Debug.DrawRay(transform.position, direction * maxDistance, Color.red, 1f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, enemyLayer);

        Vector2 splashCenter;

        if (hit.collider != null)
        {
            splashCenter = hit.point;
            Debug.Log($"Direct hit on {hit.collider.name}!");
        }
        else
        {
            splashCenter = (Vector2)transform.position + direction * maxDistance;
            Debug.Log("Missed direct hit, applying splash damage at end point.");
        }

        Debug.DrawLine(transform.position, splashCenter, Color.yellow, 1f);
        DrawCircle(splashCenter, splashRadius, Color.cyan);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(splashCenter, splashRadius, enemyLayer);
        foreach (Collider2D enemyCol in enemies)
        {
            Debug.Log($"Splash hit: {enemyCol.name}");

            enemyCol.GetComponent<EnemyHealth>().OnHit(damage);
        }
        StartCoroutine(ResetAttack());
    }

    public IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Attack", false);
    }

    void DrawCircle(Vector2 center, float radius, Color color)
    {
        int segments = 32;
        float angleStep = 360f / segments;
        Vector3 prevPoint = center + Vector2.right * radius;
        for (int i = 1; i <= segments; i++)
        {
            float angle = angleStep * i * Mathf.Deg2Rad;
            Vector3 newPoint = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            Debug.DrawLine(prevPoint, newPoint, color, 0.5f);
            prevPoint = newPoint;
        }
    }
}
