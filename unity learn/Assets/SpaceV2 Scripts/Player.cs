using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    private float speed = 15f;
    private float movement;   
    Rigidbody2D rb;

    public TextMeshProUGUI healthText;

    public GameObject projectile;
    public Transform shotPoint;

    public int health = 5;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
		{
            instance = this;
		}

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
            Instantiate(projectile, shotPoint.position, transform.rotation);
		}
	}
    
    public void TakeDamage(int damage)
	{
        Debug.Log("Took Damage!");

        health -= damage;
        healthText.text = "Health = " + health.ToString();

        if(health <= 0)
		{
            SceneManager.LoadScene(0);
            Debug.Log("Game Over!");
		}
	}

}

