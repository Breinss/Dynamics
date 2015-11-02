using UnityEngine;
using System.Collections;

public class DragonBehavior : MonoBehaviour
{
    //spawn random range for position / amount to spawn.
    public float leftRightSpeed;
    bool WeShouldGoRight = true;
    public Transform myTransform;
    float boundaryLeft = -3.7f;
    float boundaryRight = 3.7f;
    public float health;

    private GameObject _fireBall;
    private GameObject fireBall;
    public bool spawnedFire;

    private SpriteRenderer _bgSpriteRenderer;
    private Sprite sprite = Resources.Load("colored_forest", typeof(Sprite)) as Sprite;

    public float countDown;
    private bool countDownStarted;
    private bool dblFire;

    private float speed;

    void Start()
    {
        speed = 1f;
        dblFire = false;
        countDownStarted = false;
        _bgSpriteRenderer = GameObject.Find("BG").GetComponent<SpriteRenderer>();
        _bgSpriteRenderer.sprite = sprite;
        spawnedFire = false;
        _fireBall = Resources.Load("dragonfire") as GameObject;
        health = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (!countDownStarted)
        {
            StartCoroutine(CountDown());
            countDownStarted = true;
        }
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
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void Move(bool moveRight)
    {
        float movementX = moveRight ? leftRightSpeed : -leftRightSpeed;
        transform.Translate(new Vector3(movementX * Time.deltaTime * speed, 0, 0));
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(countDown);
        speed*=1.5f;
        dblFire = true;
        countDownStarted = false;
    }
    IEnumerator FireBall()
    {
        yield return new WaitForSeconds(5f);
        fireBall = Instantiate(_fireBall, new Vector3(transform.position.x, transform.position.y - 2f, 0), _fireBall.transform.rotation) as GameObject;
        spawnedFire = false;
        if (dblFire)
        {
            fireBall = Instantiate(_fireBall, new Vector3(transform.position.x-1.5f, transform.position.y - 2f, 0), _fireBall.transform.rotation) as GameObject;
            GameObject _fireBall2;
            _fireBall2 = Instantiate(_fireBall, new Vector3(transform.position.x+1.5f, transform.position.y - 2f, 0), _fireBall.transform.rotation) as GameObject;
        }
    }
}