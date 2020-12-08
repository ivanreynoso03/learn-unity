using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMachine : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = .5f;
    private Vector2 screenBounds;

    private bool isSpawning = true;


    void Start()
    {
        // Coroutine och skärm
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void SpawnEnemy()
	{
        // prefab och position
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),8);
	}

    IEnumerator asteroidWave()
    {
        while (isSpawning == true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
