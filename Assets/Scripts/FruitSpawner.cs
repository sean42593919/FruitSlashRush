using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float spawnInterval = 1.2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (!GameManager.Instance.isGameStarted) return;
        if (GameManager.Instance.isGameOver) return;

        float x = Random.Range(-6f, 6f);
        Vector3 spawnPosition = new Vector3(x, -5f, 0f);

        GameObject prefabToSpawn;

        if (Random.value < 0.2f)
        {
            prefabToSpawn = bombPrefab;
        }
        else
        {
            prefabToSpawn =
                fruitPrefabs[
                    Random.Range(0, fruitPrefabs.Length)
                ];
        }

        GameObject obj =
            Instantiate(
                prefabToSpawn,
                spawnPosition,
                Quaternion.identity
            );

        Rigidbody2D rb =
            obj.GetComponent<Rigidbody2D>();

        rb.linearVelocity =
            new Vector2(
                Random.Range(-2.5f, 2.5f),
                Random.Range(7f, 12f)
            );
    }
}