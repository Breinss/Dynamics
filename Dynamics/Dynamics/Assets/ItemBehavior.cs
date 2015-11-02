using UnityEngine;
using System.Collections;

public class ItemBehavior : MonoBehaviour
{

    private Ball _ball;
    private TargetBehavior _behavior;
    private GameManager _gameManager;
	// Use this for initialization
	void Start ()
	{
        _gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	    _behavior = GameObject.Find("TargetPaddle(Clone)").GetComponent<TargetBehavior>();
	    _ball = GameObject.Find("Ball").GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.down * Time.deltaTime * 2f;

        Debug.DrawRay(transform.position, -Vector2.up * .15f,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,.15f);

	    if (hit)
	    {
            
	        if (hit.collider.name == "Paddle")
	        {
	            _ball.GetComponent<SpriteRenderer>().sprite = _ball.sprite;
	            _ball.transform.localScale = new Vector3(.5f,.5f,.5f);
                _gameManager.spawnedSpikes++;
                Destroy(this.gameObject);
	        }
	    }

	}
}
