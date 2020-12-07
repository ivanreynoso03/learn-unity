﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 10f;

    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(transform.position.x < -xRange)
		{
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

		}

        if(transform.position.x > xRange)
		{
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
            Instantiate(laser, transform.position, laser.transform.rotation);
		}


    }
}