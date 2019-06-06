using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;
    public Transform Player;

    void Start ()
    {
         fireRate = 1.5f;
         nextFire = Time.time;
    }

    void Update()
    {
        if (Player.position.y >= transform.position.y - 0.2 && Player.position.y <= transform.position.y + 0.2)
        {
            CheckTimeToFire();
        }
        
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
