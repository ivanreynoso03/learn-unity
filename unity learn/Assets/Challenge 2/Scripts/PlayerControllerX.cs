using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float shootInterval;
    public float shootIntervalValue;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if(shootInterval <= 0)
		{
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                shootInterval = shootIntervalValue;
            }
        }
        else
        {
            shootInterval -= Time.deltaTime;
        }

    }
}
