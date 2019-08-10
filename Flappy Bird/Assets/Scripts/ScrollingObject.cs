using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(GameController.instance.scroll_speed_global, 0);
    }

    private void Update()
    {
        if (GameController.instance.game_over)
        {
            rb.velocity = Vector2.zero;
        }
    }

}
