using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject WinInterface;
    public GameObject LoseInterface;
    float xInput;
    Rigidbody2D rb;
    public float MoveSpeed;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;   
    }


    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput*MoveSpeed, 0);
    }
    void Lose()
    {
        Time.timeScale = 0;
        LoseInterface.SetActive(true);
    }
    void Win()
    {
        Time.timeScale = 0;
        WinInterface.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyControl>() != null)
        {
            Lose();
        }
    }
}
