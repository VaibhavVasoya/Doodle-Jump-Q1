using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner inst;



    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float[] platformSpawnRates;
    [SerializeField] private float levelWidth;
    [SerializeField] private float minY = 1f;
    [SerializeField] private float maxY = 3f;
    [SerializeField] public float spawnDistance = 5f;
     public Transform playerTransform;
    [SerializeField] private GameObject _spawnedPlatform;
     public float LastSpawn;

    private void Awake()
    {
        inst = this;        
    }

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
                //Debug.Log(platformPrefabs.Length);
                platformInstance.transform.parent = _spawnedPlatform.transform;
                platformInstance.transform.position = new Vector3(Random.Range(-levelWidth, levelWidth), LastSpawn + Random.Range(minY, maxY), 0);
                LastSpawn = platformInstance.transform.position.y;
           
            }
        }
    }
}
