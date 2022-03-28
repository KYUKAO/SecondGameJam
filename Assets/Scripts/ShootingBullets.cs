using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject Bullet;
    GameObject allBullets;
    float timer;
    public float IntervalTime;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public AudioSource Shoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Shoot.Play();
                allBullets = Instantiate(Bullet, bulletSpawn.position, bulletSpawn.rotation);
                allBullets.GetComponent<Rigidbody2D>().AddForce(allBullets.transform.up * bulletSpeed);
                timer = IntervalTime;
            }
        }
    }
}
