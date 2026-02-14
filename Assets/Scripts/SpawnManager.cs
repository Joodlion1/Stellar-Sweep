using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;

    public float xLimit = 20f;
    public float zLimit = 20f;
    public float ySpawn = 0f;

    [Header("Spawn Settings")]
    public float startDelay = 1f;
    public float startInterval = 2f;
    public float minInterval = 0.5f;

    [Header("Speed Settings")]
    public float startSpeed = 6f;
    public float maxSpeed = 15f;

    [Header("Difficulty Settings")]
    public float difficultyRampTime = 30f;   
    public int maxAsteroidsPerWave = 4;      

    public bool gameOver;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        float elapsed = 0f;

        while (!gameOver)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / difficultyRampTime);

            float currentInterval = Mathf.Lerp(startInterval, minInterval, t);
            float currentSpeed = Mathf.Lerp(startSpeed, maxSpeed, t);

            int asteroidsThisWave = Mathf.RoundToInt(Mathf.Lerp(1, maxAsteroidsPerWave, t));

            for (int i = 0; i < asteroidsThisWave; i++)
            {
                SpawnAsteroid(currentSpeed);
            }

            yield return new WaitForSeconds(currentInterval);
        }
    }

    void SpawnAsteroid(float speed)
    {
        if (asteroidPrefabs == null || asteroidPrefabs.Length == 0) return;

        int index = Random.Range(0, asteroidPrefabs.Length);
        GameObject prefab = asteroidPrefabs[index];

        Vector3 spawnPos = GetRandomEdgePosition();
        Vector3 dirToCenter = (Vector3.zero - spawnPos).normalized;

        GameObject asteroid = Instantiate(prefab, spawnPos, Quaternion.LookRotation(dirToCenter));

        AsteroidMovement move = asteroid.GetComponent<AsteroidMovement>();
        if (move != null)
        {
            move.SetDirection(dirToCenter);
            move.speed = speed;
        }
    }

    Vector3 GetRandomEdgePosition()
    {
        int edge = Random.Range(0, 4);

        float x = 0f;
        float z = 0f;

        switch (edge)
        {
            case 0:
                x = Random.Range(-xLimit, xLimit);
                z = zLimit;
                break;

            case 1:
                x = Random.Range(-xLimit, xLimit);
                z = -zLimit;
                break;

            case 2:
                x = xLimit;
                z = Random.Range(-zLimit, zLimit);
                break;

            case 3:
                x = -xLimit;
                z = Random.Range(-zLimit, zLimit);
                break;
        }

        return new Vector3(x, ySpawn, z);
    }
}