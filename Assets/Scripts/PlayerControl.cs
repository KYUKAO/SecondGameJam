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
    Animator anim;
    public float animFloat = 0.05f;

    public AudioSource BGM;
    public AudioSource Die;
    public AudioSource Pick;
    public AudioSource Car;

    float winTimer = 0;
    bool isWin = false;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = this.GetComponentInChildren<Animator>();
        Car.Play();
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
        if (isWin)
        {
            winTimer += Time.deltaTime;
            if (winTimer >= 3f)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene("End");
            }
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
        isWin = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyControl>() != null)
        {
            Lose();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickupComponent>() != null)
        {
            RoadManager.currentLevelState++;
            Debug.Log(RoadManager.currentLevelState);
            Destroy(collision.gameObject);
            if (RoadManager.currentLevelState >= 4)
            {
                Win();
            }
        }
    }
}
