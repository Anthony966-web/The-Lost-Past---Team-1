using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Vector2 _movement;
    public float movementSpeed;
    public Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public GameObject GFX;
    [HideInInspector] public Animator anim;


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

        if (_movement.x < 0)
        {
            // Left
            GFX.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.BroadcastMessage("isFacingRight", true);
        }
       else if (_movement.x > 0)
        {
            // Right
           GFX.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.BroadcastMessage("isFacingRight", false); 
        }
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
        rb2D.linearVelocity = new Vector2(_movement.x * movementSpeed, _movement.y * movementSpeed);
    }



    public void isFacingRight(bool isRight)
    {

        Debug.Log("Player is facing right: " + isRight);
    }    
}
