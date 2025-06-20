using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpVelocity = 10f;
    public InputSystemActions inputActions;
    private InputAction jump;
    

    private void Awake()
    {
        inputActions = new InputSystemActions();
    }
    private void OnEnable()
    {
        jump = inputActions.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        jump.Disable();
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
        }
    }
}
