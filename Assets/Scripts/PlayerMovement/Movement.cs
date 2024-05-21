using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Calculate the screen bounds
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized * speed;
    }

    void FixedUpdate()
    {
        // Move the player
        Vector2 newPosition = rb.position + movement * Time.fixedDeltaTime;

        // Clamp the player's position to keep it within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        rb.MovePosition(newPosition);
    }
}
