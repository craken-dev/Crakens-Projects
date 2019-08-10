using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D colli;
    private float ground_length;

    private void Start()
    {
        colli = GetComponent<BoxCollider2D>();
        ground_length = colli.size.x;
    }

    private void Update()
    {
        if(transform.position.x < -ground_length)
        {
            Reposition_Background();
        }
    }

    void Reposition_Background()
    {
        Vector2 offset = new Vector2(ground_length * 2, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
