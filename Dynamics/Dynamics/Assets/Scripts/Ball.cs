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

    private GameManager _gameManager;
    private bool spawnedDone;


    private DragonBehavior _dragonBehavior;

    void Start()
    {
        _paddle = GameObject.Find("Paddle");
        rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.spawnedTargets == 24)
        {
            spawnedDone = true;
        }
		currentSpeed = rb.velocity.magnitude;
		if(rb.velocity.magnitude > maxSpeed || rb.velocity.magnitude <= minSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
        if (!ballInPlay)
        {
            transform.position = new Vector3(_paddle.transform.position.x,_paddle.transform.position.y + .75f,0);
        }
        if (Input.GetButtonDown("Fire1") && !ballInPlay && spawnedDone)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity * 1.5f, 0));
        }
        _dragonBehavior = GameObject.FindGameObjectWithTag("Boss").GetComponent<DragonBehavior>();
    }
	void OnCollisionEnter2D(Collision2D coll){
		StartCoroutine(ReSize());
	    if (coll.collider.tag == "Boss")
	    {
	        _dragonBehavior.health -= 10f;
	    }
	}

	IEnumerator ReSize() {
		transform.localScale = new Vector3 (2.5f,2.5f,0);
		yield return new WaitForSeconds(.2f);
		transform.localScale = new Vector3 (2,2,0);
	}
}