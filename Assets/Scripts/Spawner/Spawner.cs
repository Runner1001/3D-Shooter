using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float respawnRate = 10;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private int totalNumberToSpawn;
    [SerializeField] private int numberToSpawnEachTime;

    private float spawnTimer;
    private int totalNumberSpawned;

    void OnEnable()
    {
        spawnTimer = respawnRate - initialSpawnDelay;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
            Spawn();
    }

    private void Spawn()
    {
        spawnTimer = 0;

        var availablePoints = spawnPoints.ToList();

        for (int i = 0; i < numberToSpawnEachTime; i++)
        {
            if (totalNumberSpawned >= totalNumberToSpawn && totalNumberToSpawn > 0)
                break;

            Spawnable prefab = GetRandomEnemyPrefab();
            if(prefab != null)
            {
                Transform randomPoint = GetRandomSpawnPoint(availablePoints);

                if(availablePoints.Contains(randomPoint))
                    availablePoints.Remove(randomPoint);

                //var enemy = Instantiate(prefab, randomPoint.position, randomPoint.rotation);

                var enemy = prefab.Get<Spawnable>(randomPoint.position, randomPoint.rotation);
                

                totalNumberSpawned++;
            }
        }
    }

    private Transform GetRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0)
            return transform;

        if(availableSpawnPoints.Count == 1)
            return availableSpawnPoints[0];

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);

        return availableSpawnPoints[index];
    }

    private Spawnable GetRandomEnemyPrefab()
    {
        if(enemyPrefabs.Length == 0)
            return null;

        if(enemyPrefabs.Length == 1)
            return enemyPrefabs[0];

        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        return enemyPrefabs[index];
    }

    private bool ShouldSpawn()
    {
        if (totalNumberSpawned >= totalNumberToSpawn && totalNumberToSpawn > 0)
            return false;

        return spawnTimer >= respawnRate;
    }
}
