using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float spawnRangeX = 10;
    [SerializeField] private float spawnPosY = 8;
    [SerializeField] private bool isSpawning = true;


    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator SpawnEnemies()
	{
        while(isSpawning == true)
		{
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
            Instantiate(asteroid, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }

    }

    public void Death()
	{
        isSpawning = false;
	}
}
