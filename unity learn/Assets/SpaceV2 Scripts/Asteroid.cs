using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody2D rb;
    private Vector2 screenBounds;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -screenBounds.y * 2)
		{
            Destroy(gameObject);
		}   
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
            Player.instance.TakeDamage(damage);
            Destroy(this.gameObject);
		}
	}
}
