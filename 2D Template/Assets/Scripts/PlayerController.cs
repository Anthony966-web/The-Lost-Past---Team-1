using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector2 _movement;
    public float movementSpeed;
    public Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.down;
    }

    void Update()
    {
       
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
}
