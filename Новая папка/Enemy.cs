using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingdistace;
    public float retretDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject Respawn;
    //public GameObject projectile;
    private Transform player;
    public bool faceLeft;
    public RectTransform AgentIndicator;
    private Rigidbody2D rb;
    public float jumpSpeed = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {

 
        if (player)
        {
            float playerDistance = Vector2.Distance(transform.position, player.position);

            if (stoppingdistace < playerDistance && playerDistance < stoppingdistace + 0.2)
            {
                transform.position = transform.position;
            }
            else if (playerDistance > stoppingdistace && playerDistance < retretDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                if(transform.position.x > player.position.x)
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                else
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

            }
            else if (playerDistance < stoppingdistace)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                if (transform.position.x > player.position.x)
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                else
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            if (player.position.y > transform.position.y) {
               rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed), ForceMode2D.Impulse);
            }



            /*if (timeBtwShots <= 0)
            {
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                Destroy(bullet, 2);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }*/
        }

        /*if (moveHorizontal < 0 && faceLeft)
        {
            flip();
        }
        else if (moveHorizontal > 0 && !faceLeft)
        {
            flip();
        }*/
           


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Agent")
        {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = Respawn.transform.position;
        }
    }
    public void flip()
    {
        faceLeft = !faceLeft;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
