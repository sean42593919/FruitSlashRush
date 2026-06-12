using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;
    public GameObject heartPrefab;

    public float baseSpawnInterval = 1.2f;
    public float minSpawnInterval = 0.35f;

    public float baseMinLaunchForce = 7f;
    public float baseMaxLaunchForce = 12f;

    public float forceIncreasePerLevel = 0.8f;
    public float intervalDecreasePerLevel = 0.08f;

    private float spawnTimer = 0f;

    void Update()
    {
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.isGameStarted) return;
        if (GameManager.Instance.isGameOver) return;
        if (Time.timeScale == 0f) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= GetCurrentSpawnInterval())
        {
            spawnTimer = 0f;
            SpawnObject();
        }
    }

    int GetDifficultyLevel()
    {
        return GameManager.Instance.score / 50;
    }

    float GetCurrentSpawnInterval()
    {
        int level = GetDifficultyLevel();

        float interval = baseSpawnInterval - level * intervalDecreasePerLevel;

        if (interval < minSpawnInterval)
        {
            interval = minSpawnInterval;
        }

        return interval;
    }

    void SpawnObject()
    {
        if (fruitPrefabs == null || fruitPrefabs.Length == 0) return;
        if (bombPrefab == null) return;
        if (heartPrefab == null) return;

        float x = Random.Range(-6f, 6f);
        Vector3 spawnPosition = new Vector3(x, -5f, 0f);

        GameObject prefabToSpawn;
        float randomValue = Random.value;

        if (GameManager.Instance.score >= 300)
        {
            if (randomValue < 0.1f)
                prefabToSpawn = heartPrefab;
            else if (randomValue < 0.5f)
                prefabToSpawn = bombPrefab;
            else
                prefabToSpawn = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        }
        else
        {
            if (randomValue < 0.1f)
                prefabToSpawn = heartPrefab;
            else if (randomValue < 0.4f)
                prefabToSpawn = bombPrefab;
            else
                prefabToSpawn = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        }

        GameObject obj = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            int level = GetDifficultyLevel();

            float minForce = baseMinLaunchForce + level * forceIncreasePerLevel;
            float maxForce = baseMaxLaunchForce + level * forceIncreasePerLevel;

            rb.linearVelocity = new Vector2(
                Random.Range(-2.5f, 2.5f),
                Random.Range(minForce, maxForce)
            );
        }
    }
}