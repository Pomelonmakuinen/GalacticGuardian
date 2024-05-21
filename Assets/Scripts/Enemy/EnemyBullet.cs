using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Optionally destroy the bullet if it goes off-screen
        if (transform.position.y < -Camera.main.orthographicSize * 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with player or other objects here
        if (other.CompareTag("player"))
        {
            Destroy(other.gameObject); // Optionally handle player damage here
            StartCoroutine(ontrigger());
        }
    }

    IEnumerator ontrigger()
    {
        Debug.Log("OnTriggerEnter");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
