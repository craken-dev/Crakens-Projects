using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jump_force = 10f;

    private Rigidbody2D rb;

    private string color;
    [SerializeField] Color blue;
    [SerializeField] Color yellow;
    [SerializeField] Color pink;
    [SerializeField] Color purple;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetRandomColor();
        AssignColor();
        Debug.Log("YOUR COLOR IS " + color.ToString());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jump_force));
        }
    }
    private void GetRandomColor()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                color = "blue";
                break;
            case 1:
                color = "yellow";
                break;
            case 2:
                color = "pink";
                break;
            case 3:
                color = "purple";
                break;
            default:
                Debug.LogError("index inespected");
                break;
        }
    }
    void AssignColor()
    {
        if(color == "blue")
        {
            GetComponent<SpriteRenderer>().color = blue;
        }else if(color == "yellow")
        {
            GetComponent<SpriteRenderer>().color = yellow;
        }
        else if(color == "pink")
        {
            GetComponent<SpriteRenderer>().color = pink;
        }
        else if(color == "purple")
        {
            GetComponent<SpriteRenderer>().color = purple;
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == color)
        {
            Debug.Log("YEEE");
        }
        else
        {
            Debug.Log("NOOO");
        }
    }
}
