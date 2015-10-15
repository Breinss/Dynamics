using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject _targetPaddle;
	private GameObject clonePaddle;
	// Use this for initialization
	void Start () {
		_targetPaddle = Resources.Load ("TargetPaddle") as GameObject;
        StartCoroutine(SpawnTargets());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < 6; i++)
        {
           yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.52f * -i, 3.5f, 0), Quaternion.identity) as GameObject;          
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.52f * -i, 3f, 0), Quaternion.identity) as GameObject;
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.52f * -i, 2.5f, 0), Quaternion.identity) as GameObject;
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.52f * -i, 2f, 0), Quaternion.identity) as GameObject;
        }
    }
}
