using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float horizontal_speed = 7f;
    [SerializeField] private bool smooth_movement = false;

    private Rigidbody2D rb;
    private float horizontal_input = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (smooth_movement)
        {
            horizontal_input = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontal_input = Input.GetAxisRaw("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal_input * horizontal_speed, rb.velocity.y);
    }
}
