using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * Speed;
    }

    void Update()
    {
        
    }
}
