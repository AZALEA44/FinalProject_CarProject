using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // The obstacle prefab to spawn
    public float spawnInterval = 2f; // Time interval between spawns
    public float spawnHeight = 10f; // Height where obstacles will spawn
    public float spawnAreaWidth = 10f; // Width of the spawn area (X axis)
    public float spawnAreaLength = 10f; // Length of the spawn area (Z axis)
    public Transform spawnArea; // The Empty Object (Spawn Area) to spawn obstacles within

    private float timer = 0f;

    // Define 5 spawn patterns
    private enum SpawnPattern { Pattern1, Pattern2, Pattern3, Pattern4, Pattern5 }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // Reset timer after spawn
        }
    }

    void SpawnObstacle()
    {
        // Choose a random spawn pattern
        SpawnPattern pattern = (SpawnPattern)Random.Range(0, 5);

        Vector3 spawnPosition = Vector3.zero;

        // Apply different patterns based on the selected pattern
        switch (pattern)
        {
            case SpawnPattern.Pattern1:
                spawnPosition = new Vector3(Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2), spawnHeight, 0);
                break;
            case SpawnPattern.Pattern2:
                spawnPosition = new Vector3(0, spawnHeight, Random.Range(-spawnAreaLength / 2, spawnAreaLength / 2));
                break;
            case SpawnPattern.Pattern3:
                spawnPosition = new Vector3(Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2), spawnHeight, Random.Range(-spawnAreaLength / 2, spawnAreaLength / 2));
                break;
            case SpawnPattern.Pattern4:
                spawnPosition = new Vector3(0, spawnHeight, 0); // Center of the spawn area
                break;
            case SpawnPattern.Pattern5:
                spawnPosition = new Vector3(Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2), spawnHeight, Random.Range(-spawnAreaLength / 2, spawnAreaLength / 2));
                break;
        }

        // Convert spawn position to world space based on the spawn area's position and rotation
        spawnPosition = spawnArea.TransformPoint(spawnPosition);

        // Instantiate the obstacle at the chosen position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
