using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public bool facingLeft;
    public Animator anim;
    public float speed = 2.0f;
    public bool watchingClown;
    public bool alreadyStopped;
    public Clown clown;
    public GameManager _gameManager;

    void Start()
    {
        clown = GameObject.Find("Clown(Clone)").GetComponent<Clown>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = this.gameObject.GetComponent<Animator>();
        if (!facingLeft)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!facingLeft && !watchingClown) transform.position += transform.right * speed * Time.deltaTime;
        if (facingLeft && !watchingClown) transform.position -= transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("HIT");
        if (this.facingLeft && collision.tag == "Left Side") Destroy(this.gameObject);
        if (!this.facingLeft && collision.tag == "Right Side") Destroy(this.gameObject);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Pay Zone" && !alreadyStopped) DetermineStopping();
    }

    public void DetermineStopping()
    {
        int r = Random.Range(0, 50);

        if (r == 1 && !watchingClown)
        {
            watchingClown = true;
            _gameManager.dailyVisitorsNum++;
            anim.SetTrigger("Watching Clown");
            anim.speed = Random.Range(0.1f, 1.5f);

        }
        if (watchingClown)
        {
            DeterminePaying();
        }
    }

    public void DeterminePaying()
    {
        int r = Random.Range(0, 10);

        if (r == 1)
        {
            _gameManager.money++;
            _gameManager.dailyMoneyEarned++;
        }
    }

    public void WalkAway()
    {
        watchingClown = false;
        anim.speed = 1;
        alreadyStopped = true;
    }
}
