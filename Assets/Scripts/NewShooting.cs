using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShooting : MonoBehaviour
{
    public GameObject Bullet;
    GameObject allBullets;
    float timer;
    public float IntervalTime;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float bulletSpeed;
    public AudioSource Shoot;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
        {

            if (timer <= 0)
            {
                Shoot.Play();
                allBullets = Instantiate(Bullet, bulletSpawn1.position, bulletSpawn1.rotation);
                allBullets = Instantiate(Bullet, bulletSpawn2.position, bulletSpawn2.rotation);
                allBullets.GetComponent<Rigidbody2D>().AddForce(allBullets.transform.up * bulletSpeed);
                timer = IntervalTime;
            }
            timer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (timer <= IntervalTime / 2)
            {
                timer = 0;
            }
        }
    }
}
