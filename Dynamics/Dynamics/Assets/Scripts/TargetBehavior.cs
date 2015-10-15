using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	private CameraShake _cameraShake;

	// Use this for initialization
	void Start () {
		_cameraShake = GameObject.Find ("Main Camera").GetComponent<CameraShake> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.collider.name == "Ball"){
			_cameraShake.shake = 1;
			Destroy(this.gameObject);
		}
	}
}
