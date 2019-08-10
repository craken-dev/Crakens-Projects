using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim_ctrl;

    [SerializeField] private float jump_force = 200f;

    private bool dead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_ctrl = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!dead)
        {
            //can flap
            if (Input.GetMouseButtonDown(0))
            {
                //flap
                //resetting the velocity to 0 (cartoon physics)
                rb.velocity = Vector2.zero;
                //adding force
                rb.AddForce(new Vector2(0, jump_force));
                //triggering animation
                anim_ctrl.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead = true;
        anim_ctrl.SetTrigger("Die");
        GameController.instance.OnBirdDied();
    }
}
