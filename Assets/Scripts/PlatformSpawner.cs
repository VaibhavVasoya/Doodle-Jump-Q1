using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float[] platformSpawnRates;
    [SerializeField] private float levelWidth;
    [SerializeField] private float minY = 1f;
    [SerializeField] private float maxY = 3f;
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float LastSpawn;

    private void Start()
    {
        LastSpawn = playerTransform.position.y - spawnDistance;
    }

    private void Update()
    {
        if (playerTransform.position.y > LastSpawn - spawnDistance)
        {
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            if (Random.value < platformSpawnRates[i])
            {
                GameObject platformInstance = Instantiate(platformPrefabs[i]);
                platformInstance.transform.position = new Vector3(Random.Range(-levelWidth, levelWidth), LastSpawn + Random.Range(minY, maxY), 0);
                LastSpawn = platformInstance.transform.position.y;
            }
        }
    }
}
