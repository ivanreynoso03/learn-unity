using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float speed = 10;
    private float cooldown;
    public float cooldownValue = 15;

    Vector2 screenBounds;

	private void Start()
	{
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
	private void Update()
    {

        if(transform.position.y > screenBounds.y * 2)
		{
            Destroy(gameObject);
		}


        if (Input.GetMouseButtonDown(0) == true && cooldown <= 0)
        {
            CreateBullet(-30f);
            CreateBullet(-15f);
            CreateBullet(0f);
            CreateBullet(15f);
            CreateBullet(30f);

            cooldown = cooldownValue;
		}
		else
		{
            cooldown -= Time.deltaTime;
            Debug.Log(cooldown);
		}
    }

    private void CreateBullet(float angleOffset = 0f)
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = transform.position;

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Quaternion.AngleAxis(angleOffset, Vector3.forward) * transform.up * speed * 100.0f);
    }
}
