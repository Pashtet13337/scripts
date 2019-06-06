using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;


    DCharacterController target;
    Vector2 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<DCharacterController>();

       if(transform.position.x > target.transform.position.x)
       {
            moveDirection = Vector2.left * moveSpeed;
       }
       else
        {
            moveDirection = Vector2.right * moveSpeed;
            transform.localScale = new Vector3(-0.37f, 0.25f, 1);
        }

       
        rb.velocity = moveDirection;
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<PlayerIndicate>().DamagePlayer(10);
        }
    }
}
