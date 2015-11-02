using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	private CameraShake _cameraShake;
    private GameManager _gameManager;

    private GameObject _spikeyBall;
    private GameObject spikeyBall;


	// Use this for initialization
	void Start ()
	{
        _spikeyBall = Resources.Load("ball_spiked") as GameObject;
		_cameraShake = GameObject.Find ("Main Camera").GetComponent<CameraShake> ();
        _gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.collider.name == "Ball"){
			_cameraShake.shake = 1;
            _gameManager.spawnedTargets--;
		        if (Random.value <= 0.9f && _gameManager.spawnedSpikes == 0)
		        {
		            spikeyBall = Instantiate(_spikeyBall, transform.position, Quaternion.identity) as GameObject;
		            _gameManager.spawnedSpikes++;
		        }

		    Destroy(this.gameObject);
		}
	}
}
