﻿using System;
using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private GameObject _ball;
    private Rigidbody2D _rigidbody2DBall;
    private float ballAngle;
    private bool touchingSides;
        void Start()
        {
            touchingSides = false;
            _ball = GameObject.Find("Ball");
            _rigidbody2DBall = _ball.GetComponent<Rigidbody2D>();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.A) && !touchingSides)
            {
                transform.position += Vector3.left * Time.deltaTime * 6;
            }
            if (Input.GetKey(KeyCode.D) && !touchingSides)
            {
                transform.position += Vector3.right * Time.deltaTime * 6;
            }
        }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "Ball")
        {
            ballAngle = _ball.transform.position.x - transform.position.x;
            _rigidbody2DBall.AddForce(new Vector2(100f * ballAngle, 0));
        }
        if (col.collider.tag == "Sides")
        {
            touchingSides = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Sides")
        {
            touchingSides = false;
        }
    }
}