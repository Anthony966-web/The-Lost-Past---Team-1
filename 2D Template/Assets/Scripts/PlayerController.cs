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



}
