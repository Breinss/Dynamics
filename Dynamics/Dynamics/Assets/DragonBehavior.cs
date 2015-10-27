using UnityEngine;
using System.Collections;

public class DragonBehavior : MonoBehaviour
{
    //spawn random range for position / amount to spawn.
    public float leftRightSpeed;
    bool WeShouldGoRight = true;
    Vector3 dropAmount = new Vector3(0, 1, 0);
    public Transform myTransform;
    float boundaryLeft = -3.7f;
    float boundaryRight = 3.7f;
    public float health;

    private GameObject _fireBall;
    private GameObject fireBall;
    public bool spawnedFire;

    void Start()
    {
        spawnedFire = false;
        _fireBall = Resources.Load("dragonfire") as GameObject;
        health = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawnedFire)
        {
            spawnedFire = true;
            StartCoroutine(FireBall());
        }
        // 6.2 is a "magic number"; where did it come from?  I'm going to assume that you want 
        // to use your boundary variables instead.
        if ((transform.position.x >= boundaryRight) || (transform.position.x <= boundaryLeft))
        {
            // A boundary has been reached; swap the travel direction and move down a level.
            WeShouldGoRight = !WeShouldGoRight;
            //print("Switching directions; now moving " + (WeShouldGoRight ? "Right" : "Left"));
        }

        Move(WeShouldGoRight);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Move(bool moveRight)
    {
        float movementX = moveRight ? leftRightSpeed : -leftRightSpeed;
        transform.Translate(new Vector3(movementX * Time.deltaTime, 0, 0));
    }

    IEnumerator FireBall()
    {
        yield return new WaitForSeconds(5f);
        fireBall = Instantiate(_fireBall, new Vector3(transform.position.x, transform.position.y - 2f, 0), _fireBall.transform.rotation) as GameObject;
        spawnedFire = false;
    }
}