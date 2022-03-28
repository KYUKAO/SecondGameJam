using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadControl : MonoBehaviour
{
    public float SimpleSpeed;
    Rigidbody2D rb;
    public Transform triggerPoint;
    float timer = 0;
    public float DestroyTime;
    private void Start()
    {
        triggerPoint = this.transform.GetChild(0);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity=Vector2.down*SimpleSpeed;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= DestroyTime)
        {
            Destroy(this.gameObject);
        }
      
    }
}
