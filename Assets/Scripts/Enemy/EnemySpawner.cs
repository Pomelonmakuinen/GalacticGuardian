using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    private float nextSpawn = 0f;
    public float spawnXMin = -7f;
    public float spawnXMax = 7f;
    public float spawnY = 6f;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public int maxEnemiesOnScreen = 3;
    public static EnemySpawner Instance { get; private set; }

    void Awake()
    {
        // Ensure there's only one instance of EnemySpawner
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check if the number of active enemies is less than the maximum allowed
        if (Time.time > nextSpawn && activeEnemies.Count < maxEnemiesOnScreen)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnEnemy();
        }

        // Clean up the list of active enemies by removing any that have been destroyed
        activeEnemies.RemoveAll(enemy => enemy == null);
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(newEnemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
    }
}
