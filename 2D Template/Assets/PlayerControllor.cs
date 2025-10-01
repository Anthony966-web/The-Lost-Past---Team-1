using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllor : MonoBehaviour
{

    public Vector2 _movement;
    public float movementSpeed;
    public Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(_movement.x * movementSpeed, _movement.y * movementSpeed);
    }
}
