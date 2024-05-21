using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 2f;
    private float directionChangeTimer;
    private Vector2 movementDirection;

    void Start()
    {
        SetRandomMovementDirection();
        directionChangeTimer = changeDirectionTime;
    }

    void Update()
    {
        // Move the enemy in the current direction
        transform.Translate(movementDirection * speed * Time.deltaTime);

        // Update the timer and change direction if needed
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            SetRandomMovementDirection();
            directionChangeTimer = changeDirectionTime;
        }

        // Optionally destroy the enemy if it goes off-screen on the x-axis
        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect ||
            transform.position.x > Camera.main.orthographicSize * Camera.main.aspect)
        {
            Destroy(gameObject);
        }
    }

    void SetRandomMovementDirection()
    {
        // Set a random direction for horizontal movement
        float randomX = Random.Range(-1f, 1f);
        movementDirection = new Vector2(randomX, 0).normalized;
    }

    void OnDestroy()
    {
        // Notify the spawner that this enemy has been destroyed
        EnemySpawner.Instance.RemoveEnemy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with the player or other objects here
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Optionally handle player damage here
            Destroy(gameObject);
        }
    }
}
