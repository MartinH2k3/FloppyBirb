using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpVelocity = 10f;
    public InputSystemActions inputActions;
    private InputAction _jump;
    private GameManager _gameManager;
    

    private void Awake()
    {
        inputActions = new InputSystemActions();
    }

    private void Start()
    {
        var obj = GameObject.FindGameObjectWithTag("GameManager");
        if (obj != null)
        {
            _gameManager = obj.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found! Make sure it is tagged correctly.");
        }
    }

    private void OnEnable()
    {
        _jump = inputActions.Player.Jump;
        _jump.Enable();
        _jump.performed += Jump;
    }

    private void OnDisable()
    {
        _jump.Disable();
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && !_gameManager.isGameOver)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6) _gameManager.GameOver();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6) _gameManager.GameOver();
    }
}
