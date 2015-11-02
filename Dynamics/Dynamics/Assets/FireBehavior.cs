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

        Debug.DrawRay(transform.position, -Vector2.up * .15f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .15f);

        if (hit)
        {

            if (hit.collider.name == "Paddle")
            {
                _paddleBehavior.health -= 10;
            }
        }
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
