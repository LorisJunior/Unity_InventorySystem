using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public float Speed = 5f;

    private Vector2 move;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    private void Start()
    {
        moveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        move = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + move * Speed * Time.deltaTime);
    }
}
