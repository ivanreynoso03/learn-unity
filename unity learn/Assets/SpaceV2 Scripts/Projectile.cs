using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > screenBounds.y * 2)
        {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
            Destroy(other.gameObject);
            Destroy(this.gameObject);
		}
	}
}
