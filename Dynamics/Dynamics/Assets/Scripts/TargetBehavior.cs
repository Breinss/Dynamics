using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	private CameraShake _cameraShake;
    private GameManager _gameManager;


	// Use this for initialization
	void Start () {
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
			Destroy(this.gameObject);
		}
	}
}
