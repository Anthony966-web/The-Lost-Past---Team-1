using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public Vector2 boxSize;
    public LayerMask boxLayer;

    public void InteractWith(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;


        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1.5f, 1.5f), 0, Vector2.zero, 0, boxLayer);

        if (hit && hit.collider.TryGetComponent(out Interactable interactable))
        {
            interactable.onInteract.Invoke();
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}