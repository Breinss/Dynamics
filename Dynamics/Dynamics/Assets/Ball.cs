using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;

    private GameObject _paddle;
    private Rigidbody2D rb;
    private bool ballInPlay;

    void Awake()
    {
        _paddle = GameObject.Find("Paddle");
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (!ballInPlay)
        {
            transform.position = new Vector3(_paddle.transform.position.x,_paddle.transform.position.y + .75f,0);
        }
        if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity * 1.5f, 0));
        }
    }
}