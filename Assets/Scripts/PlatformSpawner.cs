using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> platformPrefabs;
    [SerializeField] private List<int> platformPoolSizes;
    [SerializeField] private List<float> platformSpawnRates;
    [SerializeField] private float levelWidth;
    [SerializeField] private float minY = 1f;
    [SerializeField] private float maxY = 3f;
    [SerializeField] private float spawnDistance = 5f;

    private Transform playerTransform;
    private float lastSpawnY;
    private List<GameObject[]> platformPools;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastSpawnY = playerTransform.position.y;
        platformPools = new List<GameObject[]>();

        // Create a pool for each platform type
        for (int i = 0; i < platformPrefabs.Count; i++)
        {
            GameObject[] platformPool = new GameObject[platformPoolSizes[i]];
            for (int j = 0; j < platformPoolSizes[i]; j++)
            {
                platformPool[j] = Instantiate(platformPrefabs[i], Vector3.zero, Quaternion.identity);
                platformPool[j].SetActive(false);
            }
            platformPools.Add(platformPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y > lastSpawnY - spawnDistance)
        {
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        for (int i = 0; i < platformPrefabs.Count; i++)
        {
            // Check if it's time to spawn this platform type
            if (Random.value < platformSpawnRates[i])
            {
                GameObject[] platformPool = platformPools[i];
                for (int j = 0; j < platformPoolSizes[i]; j++)
                {
                    if (!platformPool[j].activeInHierarchy)
                    {
                        platformPool[j].transform.position = new Vector3(Random.Range(-levelWidth, levelWidth), lastSpawnY + Random.Range(minY, maxY), 0);
                        platformPool[j].SetActive(true);
                        lastSpawnY = platformPool[j].transform.position.y;
                        break;
                    }
                }
            }
        }
    }
}
