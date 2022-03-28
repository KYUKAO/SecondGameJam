using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    Transform recyclePoint;
    Vector3 startTransform;
    float instantiateTriggerValue;
    public Transform InstantiateLine;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * Speed;
        recyclePoint = this.transform.GetChild(0).transform;
        instantiateTriggerValue = InstantiateLine.position.y;
        startTransform = this.transform.position;
    }
    private void Update()
    {
        if (recyclePoint.position.y<instantiateTriggerValue)
        {
            this.transform.position = startTransform;
        }
    }
}
