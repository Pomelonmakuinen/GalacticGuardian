using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Optionally destroy the laser if it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize * 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with enemies or other objects here
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Hit enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

