using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        movement =  value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(movement.x, 0, movement.y) * Time.fixedDeltaTime);
    }
}
