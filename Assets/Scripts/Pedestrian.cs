using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public bool facingLeft;
    public Animator anim;
    public float speed = 2.0f;
    public bool watchingClown;
    public bool alreadyStopped;
    public bool alreadyPaid;
    public Clown clown;
    public GameManager _gameManager;

    // public int payNum;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        clown = _gameManager.clown;  // GameObject.Find("Clown(Clone)").GetComponent<Clown>();
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

        if (watchingClown)
        {
            DeterminePaying();
        }
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
        int r = Random.Range(0, (150 - (_gameManager.clownStylePoints * 10)));

        if ((r == 1 && !watchingClown) || _gameManager.clownStylePoints * 10 >= 150 )
        {
            watchingClown = true;
            _gameManager.dailyVisitorsNum++;
            anim.SetTrigger("Watching Clown");
            anim.speed = DetermineWatchTime();

        }
        
    }

    public void DeterminePaying()
    {
        int r = Random.Range(0, (500 - (_gameManager.clownSkillPoints * 50)));

        if ((r == 1 && !alreadyPaid) || (_gameManager.clownSkillPoints * 50 >= 500 && !alreadyPaid))
        {
            _gameManager.money += _gameManager.clownSkillPoints;
            _gameManager.dailyMoneyEarned += _gameManager.clownSkillPoints;
            alreadyPaid = true;
        }
    }

    public float DetermineWatchTime()
    {
        float watchtime = Random.Range((1.0f / _gameManager.clownGoofinessPoints), 1.0f);
        if (_gameManager.clownGoofinessPoints == 1) watchtime = 1.0f;
        return watchtime;
    }

    public void WalkAway()
    {
        watchingClown = false;
        anim.speed = 1;
        alreadyStopped = true;
    }
}
