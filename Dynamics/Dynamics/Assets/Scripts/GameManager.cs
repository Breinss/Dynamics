using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject _targetPaddle;
	private GameObject clonePaddle;
	// Use this for initialization
	void Start () {
		_targetPaddle = Resources.Load ("TargetPaddle") as GameObject;
		for (int i = 0; i < 6; i++) {
			clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.5f * -i, 3.5f, 0), Quaternion.identity) as GameObject;					
		}
		for (int i = 0; i < 6; i++) {
			clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.5f * -i, 3f, 0), Quaternion.identity) as GameObject;					
		}
		for (int i = 0; i < 6; i++) {
			clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.5f * -i, 2.5f, 0), Quaternion.identity) as GameObject;					
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
