using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadControl : MonoBehaviour
{
    public float SimpleSpeed;
    Rigidbody2D rb;
    private void Start()
    {
        rb.velocity=Vector2.down*SimpleSpeed;
    }
}
