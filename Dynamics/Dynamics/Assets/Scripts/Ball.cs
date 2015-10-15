using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity;


    private GameObject _paddle;
    private Rigidbody2D rb;
    private bool ballInPlay;

	public float maxSpeed;
	public float minSpeed;
	public float currentSpeed;

	private Renderer _renderer;

    void Awake()
    {
        _paddle = GameObject.Find("Paddle");
        rb = GetComponent<Rigidbody2D>();
		_renderer = GetComponent<Renderer> ();
    }

    void Update()
    {
		currentSpeed = rb.velocity.magnitude;
		if(rb.velocity.magnitude > maxSpeed || rb.velocity.magnitude <= minSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
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
	void OnCollisionEnter2D(Collision2D coll){
		//StartCoroutine(ReSize());
	}

	IEnumerator ReSize() {
		transform.localScale = new Vector3 (.5f,.5f,0);
		yield return new WaitForSeconds(.2f);
		transform.localScale = new Vector3 (.4f,.4f,0);
	}
}