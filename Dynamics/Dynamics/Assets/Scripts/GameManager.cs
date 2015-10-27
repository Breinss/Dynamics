using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject _targetPaddle;
	private GameObject clonePaddle;

    private GameObject dragonBoss;
    private GameObject _dragonBoss;
    private bool bossSpawned;

    private bool targetSpawned;

    public int spawnedTargets;
	// Use this for initialization
	void Start ()
	{
	    targetSpawned = false;
	    bossSpawned = false;
		_targetPaddle = Resources.Load ("TargetPaddle") as GameObject;
        _dragonBoss = Resources.Load("dragon_boss") as GameObject;
        StartCoroutine(SpawnTargets());
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (spawnedTargets == 24)
	    {
	        targetSpawned = true;
	    }
	    if (spawnedTargets <= 0 && !bossSpawned && targetSpawned)
	    {
            dragonBoss = Instantiate(_dragonBoss, new Vector3(_dragonBoss.transform.position.x, _dragonBoss.transform.position.y, -10), Quaternion.identity) as GameObject;
	        bossSpawned = true;
	    }
	}

    IEnumerator SpawnTargets()
    {
        for (int i = 0; i < 6; i++)
        {
           yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.25f * -i, 3.5f, 0), Quaternion.identity) as GameObject;
            spawnedTargets++;
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f); 
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.25f * -i, 3f, 0), Quaternion.identity) as GameObject;
            spawnedTargets++;
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f);
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.25f * -i, 2.5f, 0), Quaternion.identity) as GameObject;
            spawnedTargets++;
        }
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.1f);
            clonePaddle = Instantiate(_targetPaddle, new Vector3(_targetPaddle.transform.position.x - 1.25f * -i, 2f, 0), Quaternion.identity) as GameObject;
            spawnedTargets++;
        }
    }
}
