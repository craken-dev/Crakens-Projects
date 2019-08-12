using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotation_speed = 100f;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, rotation_speed * Time.deltaTime);
    }
}
