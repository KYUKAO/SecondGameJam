using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject WinInterface;
    public GameObject LoseInterface;
    float xInput;
    Rigidbody2D rb;
    public float MoveSpeed;
    SpriteRenderer sp;

    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {if(this.GetComponent<Collider2D>().enabled == true)
            {
                this.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<Collider2D>().enabled = true;
            }

        }
        Debug.Log(xInput);
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
        SceneManager.LoadScene("End");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyControl>() != null)
        {
            Lose();
        }
    }
}
