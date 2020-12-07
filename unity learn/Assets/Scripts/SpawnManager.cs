using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalprefabs;
    private float spawnRangeX = 10;
    private float spawnPosY = 8;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
	{
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
        int animalIndex = Random.Range(0, animalprefabs.Length);
        Instantiate(animalprefabs[animalIndex], spawnPos, animalprefabs[animalIndex].transform.rotation);
    }
}
