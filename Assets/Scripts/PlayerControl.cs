using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject LoseInterface;
    float xInput;
    Rigidbody2D rb;
    public float MoveSpeed;
    SpriteRenderer sp;
<<<<<<< HEAD
    Animator anim;
    float animFloat = 0.005f;
=======

    public AudioSource BGM;
    public AudioSource Die;
    public AudioSource Pick;
    public AudioSource Car;

<<<<<<< Updated upstream
=======
>>>>>>> 26c8901f74515d1401ca1f577e6725c4162dfc66
>>>>>>> Stashed changes
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
<<<<<<< Updated upstream
        Car.Play();
=======
<<<<<<< HEAD
        anim = this.GetComponentInChildren<Animator>();
=======
        Car.Play();
>>>>>>> 26c8901f74515d1401ca1f577e6725c4162dfc66
>>>>>>> Stashed changes
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

        if (xInput < -animFloat)
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
        }
        if (xInput >= -animFloat && xInput <= animFloat)
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }

        if (xInput > animFloat)
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
        }

    }
    void Lose()
    {
        Time.timeScale = 0;
        LoseInterface.SetActive(true);
        BGM.Stop();
        Die.Play();
        Car.Stop();
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
