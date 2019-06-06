using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject Respawn;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            SoundScript.PlaySound("playerDeath");
            other.gameObject.GetComponent<PlayerIndicate>().Heal(100);
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = Respawn.transform.position;
        }
    }

}