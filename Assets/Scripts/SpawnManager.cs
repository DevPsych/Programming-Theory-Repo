using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] int enemyLevel = 0;
    [SerializeField] int enemiesToSpawn = 4;
    [SerializeField] int enemyCount = 0;
    [SerializeField] int additionalSpawn = 1;
    [SerializeField] int maxSpawn = 6;
    [SerializeField] int minSpawn = 4;

    [SerializeField] float xRange = 40.0f;
    [SerializeField] float zRange = 40.0f;
    [SerializeField] float spawnPosition = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyTop(enemyLevel, enemiesToSpawn);
        SpawnEnemyLeft(enemyLevel, enemiesToSpawn);
        SpawnEnemyBottom(enemyLevel, enemiesToSpawn);
        SpawnEnemyRight(enemyLevel, enemiesToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            enemiesToSpawn += additionalSpawn;
            if (enemiesToSpawn > maxSpawn)
            {
                enemyLevel++;
                enemiesToSpawn = minSpawn;
            }
            SpawnEnemyTop(enemyLevel, enemiesToSpawn);
            SpawnEnemyLeft(enemyLevel, enemiesToSpawn);
            SpawnEnemyBottom(enemyLevel, enemiesToSpawn);
            SpawnEnemyRight(enemyLevel, enemiesToSpawn);
        }
    }

    void SpawnEnemyTop(int enemyLevel, int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyLevel], RandomizeTopSpawnPosition(), enemyPrefab[enemyLevel].transform.rotation);
        }
    }

    void SpawnEnemyLeft(int enemyLevel, int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyLevel], RandomizeLeftSpawnPosition(), enemyPrefab[enemyLevel].transform.rotation);
        }
    }

    void SpawnEnemyBottom(int enemyLevel, int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyLevel], RandomizeBottomSpawnPosition(), enemyPrefab[enemyLevel].transform.rotation);
        }
    }

    void SpawnEnemyRight(int enemyLevel, int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[enemyLevel], RandomizeRightSpawnPosition(), enemyPrefab[enemyLevel].transform.rotation);
        }
    }

    private Vector3 RandomizeTopSpawnPosition()
    {
        float xPosition = Random.Range(-xRange, xRange);

        return new Vector3(xPosition, enemyPrefab[enemyLevel].transform.position.y, spawnPosition);
    }

    private Vector3 RandomizeLeftSpawnPosition()
    {
        float zPosition = Random.Range(-zRange, zRange);

        return new Vector3(-spawnPosition, enemyPrefab[enemyLevel].transform.position.y, zPosition);
    }

    private Vector3 RandomizeBottomSpawnPosition()
    {
        float xPosition = Random.Range(-xRange, xRange);

        return new Vector3(xPosition, enemyPrefab[enemyLevel].transform.position.y, -spawnPosition);
    }

    private Vector3 RandomizeRightSpawnPosition()
    {
        float zPosition = Random.Range(-zRange, zRange);

        return new Vector3(spawnPosition, enemyPrefab[enemyLevel].transform.position.y, zPosition);
    }
}