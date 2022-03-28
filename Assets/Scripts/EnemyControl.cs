using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float HorizontalSpeed;
    public float AccelerateSpeed;
    float timer ;
    public float changeDirectionTIme;
    public enum EnemyType
    {
        Static,
        SpeedUp,
        AI,
    }
    public EnemyType currentEnemyType;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timer = changeDirectionTIme;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        Move();
    }
    void Move()
    {
        switch (currentEnemyType)
        {
            case (EnemyType.Static):
                rb.velocity= Vector2.down * Speed;
                break;
            case (EnemyType.SpeedUp):
                rb.velocity = Vector2.down * (Speed- AccelerateSpeed);
                break;
            case (EnemyType.AI):
                if (timer >= changeDirectionTIme)
                {
                    var rand = Random.Range(-1f, 1f);
                    rb.velocity = new Vector2(rand * HorizontalSpeed, (-1)*(Speed - AccelerateSpeed));
                    timer = 0;
                }
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControl>() == null)
        {
            timer = changeDirectionTIme;
            Debug.Log("Collided");
        }
    }
}
