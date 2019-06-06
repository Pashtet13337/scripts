using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DCharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded = false;

    private bool canMove = true;
    private float timeNotMove = 1;
    private int flashCount;
    private GameObject lastFlash;

    public float speed = 1;
    public float jumpSpeed = 5;
    public float groundedRadius = 0.2f;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool faceLeft;
    public Text health;

    public Text flashText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flashCount = 0;
    }

    void Update()
    {
        if (flashCount == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        // считываем нажатие клавиш
        float moveHorizontal = Input.GetAxis("Horizontal");


        // передаем значение нажатия клавиш или геймпада в горизонтальное ускорение
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        // по умолчанию ставим значение grounded false
        grounded = false;

        // собираем все коллайдеры, рядом с которыми находится объект groundCheck, только из проверяющего слоя whatIsGround
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);

        // перебираем коллайдеры, делаем проверку их гейм обджекта на не соответсвие с гейм обжектом игрока
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }

        // если мы на земле и нажат пробел, то придаем ускорение вверх
        if (grounded && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed), ForceMode2D.Impulse);
        }
        if (moveHorizontal < 0 && faceLeft)
        {
            flip();
        }
        else if (moveHorizontal > 0 && !faceLeft)
        {
            flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin") && lastFlash != other.gameObject)
        {
            lastFlash = other.gameObject;
            Destroy(other.gameObject);
            flashCount++;
            //PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            flashText.text = "Flash: " + flashCount + " / 3";//PlayerPrefs.GetInt("coin").ToString();
        }
    }

    public void flip()
    {
        faceLeft = !faceLeft;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}