using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float HorizontalSpeed;
    float accelerateSpeed;
    float timer ;
    float speedTimer;
    public float SpeedUpRate;
    public float MaxSpeed;
    
    public float ChangeDirectionTIme;
    public float SpeedUpIntervalTime;
    SpriteRenderer sp;
    public Sprite DeadSprite;
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
        timer = ChangeDirectionTIme;
        speedTimer = SpeedUpIntervalTime;
        sp = this.GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        speedTimer += Time.deltaTime;
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
                Debug.Log(accelerateSpeed);
                if (speedTimer >= SpeedUpIntervalTime)
                {
                    accelerateSpeed = accelerateSpeed + speedTimer * SpeedUpRate;
                }
                if (accelerateSpeed >= MaxSpeed)
                {
                    speedTimer = 0f;
                    accelerateSpeed = 0f;
                }
                rb.velocity = Vector2.down * (Speed - accelerateSpeed);
                break;
            case (EnemyType.AI):
                if (timer >= ChangeDirectionTIme)
                {
                    var rand = Random.Range(-1f, 1f);
                    rb.velocity = new Vector2(rand * HorizontalSpeed, (-1)*(Speed - accelerateSpeed));
                    timer = 0;
                }
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControl>() == null)
        {
            timer = ChangeDirectionTIme;
            Debug.Log("Collided");
        }
    }
    void Die()
    {
        sp.sprite = DeadSprite;
        Invoke("DestroyItself",1f);
    }
    void DestroyItself()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletComponent>())
        {
            Die();
        }
    }
}
