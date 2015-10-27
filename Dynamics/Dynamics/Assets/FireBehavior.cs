using UnityEngine;
using System.Collections;

public class FireBehavior : MonoBehaviour
{

    private PaddleBehavior _paddleBehavior;
    private float speed;

	// Use this for initialization
	void Start ()
	{
	    _paddleBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PaddleBehavior>();
	    speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * Time.deltaTime * speed;
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            _paddleBehavior.health -= 10f;
        }
    }
}
