using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject Bullet;
    GameObject allBullets;
    public float Timer;
    public Transform bulletSpawn;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                allBullets = Instantiate(Bullet, bulletSpawn.position, bulletSpawn.rotation);
                allBullets.GetComponent<Rigidbody2D>().AddForce(allBullets.transform.up * bulletSpeed);
                Timer = 2;
            }
        }
    }
}
