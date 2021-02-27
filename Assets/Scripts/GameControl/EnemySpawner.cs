using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnFrecuency;

    private float spawnFrecuencyCounter;
    private bool spawnAvailable;

    // Patrón Object Pool
    [SerializeField]
    private Transform enemyPool;
    private const int ENEMY_POOL_SIZE = 10;
    private GameObject[] enemies;
    private int enemyNumber;

    [SerializeField]
    private Transform spawnPoints;
    private Vector3[] spawnPointsPositions;

    private void Start()
    {
        InitializeEnemyPool();
        InitializeSpawnPoints();

        spawnFrecuencyCounter = spawnFrecuency;
    }

    private void Update()
    {
        spawnFrecuencyCounter -= Time.deltaTime;
        spawnAvailable = spawnFrecuencyCounter < 0f;

        if (spawnAvailable) SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        spawnFrecuencyCounter = spawnFrecuency;

        enemyNumber++;

        if (enemyNumber > ENEMY_POOL_SIZE - 1) enemyNumber = 0;

        Vector3 spawnPoint = spawnPointsPositions[Random.Range(0, spawnPointsPositions.Length)];
        enemies[enemyNumber].transform.position = spawnPoint;
        enemies[enemyNumber].SetActive(true);
    }

    private void InitializeEnemyPool()
    {
        enemies = new GameObject[ENEMY_POOL_SIZE];

        for (int i = 0; i < ENEMY_POOL_SIZE; i++) {
            enemies[i] = Instantiate(enemyPrefab, enemyPool.position, Quaternion.identity, enemyPool);
        }
    }

    private void InitializeSpawnPoints()
    {
        spawnPointsPositions = new Vector3[spawnPoints.childCount];

        int i = 0;
        foreach (Transform child in spawnPoints) {
            //spawnPointsPositions[i] = child.position;
            spawnPointsPositions[i] = new Vector3(child.position.x, child.position.y - 1, child.position.z);
            i++;
        }
    }
}
