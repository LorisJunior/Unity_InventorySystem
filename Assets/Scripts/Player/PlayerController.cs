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
    private Vector2 lookDirection;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        moveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        if (!Mathf.Approximately(move.x, 0f) || !Mathf.Approximately(move.y, 0f))
        {
            lookDirection = move;
            lookDirection.Normalize();
        }

        animator.SetFloat(AnimationHash.moveX, lookDirection.x);
        animator.SetFloat(AnimationHash.moveY, lookDirection.y);
        animator.SetFloat(AnimationHash.speed, move.magnitude);
    }

    private void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + move * Speed * Time.deltaTime);
    }
}
