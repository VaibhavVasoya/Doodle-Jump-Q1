using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject PlatformPrefab;
    [SerializeField] private int platformCount;
    [SerializeField] private float levelWidth;
    [SerializeField] private float minY = 1f;
    [SerializeField] private float maxY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3(-1f,-2f,transform.position.z);

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(PlatformPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
