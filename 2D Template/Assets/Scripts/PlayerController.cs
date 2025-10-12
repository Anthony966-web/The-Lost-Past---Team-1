using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Vector2 _movement;
    private float movementSpeed;
    public float speedMultiplier;
    public float baseMoveSpeed;

    public Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public GameObject GFX;
    [HideInInspector] public Animator anim;


    [Header("Attack Settings")]
    public float damage = 25f;
    public float maxDistance = 100f;
    public LayerMask enemyLayer; // assign “Enemy” layer in Inspector
    public float splashRadius = 1.5f; // how far around the ray's hit point to also hit enemies

    [Header("References")]
    public Camera cam; // assign your camera in the inspector (e.g., MainCamera)


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

        //if (_movement.x < 0)
        //{
        //    // Left
        //    GFX.GetComponent<SpriteRenderer>().flipX = false;
            
        //}
        //else if (_movement.x > 0)
        //{
        //    // Right
        //    GFX.GetComponent<SpriteRenderer>().flipX = true;
            
        //}
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
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

        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogWarning("No camera assigned!");
                return;
            }
        }

        // Get the mouse position in world space
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Direction from player to mouse
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;

        // Visualize the ray
        Debug.DrawRay(transform.position, direction * maxDistance, Color.red, 1f);

        // Cast ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, enemyLayer);

        // Determine where to center the splash
        Vector2 splashCenter;

        if (hit.collider != null)
        {
            // Hit something → splash centered on hit point
            splashCenter = hit.point;
            Debug.Log($"Direct hit on {hit.collider.name}!");
        }
        else
        {
            // Missed → splash at max range in that direction
            splashCenter = (Vector2)transform.position + direction * maxDistance;
            Debug.Log("Missed direct hit, applying splash damage at end point.");
        }

        // 🔸 Visualize splash radius
        Debug.DrawLine(transform.position, splashCenter, Color.yellow, 1f);
        DrawCircle(splashCenter, splashRadius, Color.cyan);

        // Find all enemies in splash radius
        Collider2D[] enemies = Physics2D.OverlapCircleAll(splashCenter, splashRadius, enemyLayer);
        foreach (Collider2D enemyCol in enemies)
        {
            Debug.Log($"Splash hit: {enemyCol.name}");

            // Apply damage if they have a health script
            //EnemyHealth2D enemy = enemyCol.GetComponent<EnemyHealth2D>();
            //if (enemy != null)
            //{
            //    enemy.TakeDamage(damage);
            //}

            enemyCol.GetComponent<Goblin>().OnHit(damage);
        }
    }

    // helper for visualizing radius
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
