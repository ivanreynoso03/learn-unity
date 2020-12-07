using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 10f;
    public float lowerBounds = -5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);


        if(transform.position.y < lowerBounds)
		{
            transform.position = new Vector3(Random.Range(-9, 9), 8, 0);
		}

    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
            Destroy(gameObject);
		}

        if(other.tag == "Laser")
		{
            Destroy(other.gameObject);
            Destroy(this.gameObject);
		}
	}
}
