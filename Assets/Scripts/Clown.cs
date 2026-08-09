using UnityEngine;

public class Clown : MonoBehaviour
{
    public GameObject[] ballPlacments;
    public Animator anim;
    public GameManager _gameManager;

    //public int actionPoints;
    //public int goofiness;
    //public int skill;
    //public int style;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ballPlacments = new GameObject[10];
        for (int i = 0; i < this.gameObject.transform.childCount - 1; i++)
        {
            ballPlacments[i] = this.gameObject.transform.GetChild(i + 1).gameObject;
        }

        //goofiness = _gameManager.clownGoofinessPoints;
        //skill = _gameManager.clownSkillPoints;
        //style = _gameManager.clownStylePoints;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("BallNum", _gameManager.ownedBallsInt);
    }

    public void UpdateBalls()
    {
        //int i = _gameManager.ownedBallsInt;
        Debug.Log("Running Update Ball");
        for (int i = 0; i <= _gameManager.ownedBallsInt; i++)
        {
            ballPlacments[i].gameObject.SetActive(true);
            ballPlacments[i].GetComponent<SpriteRenderer>().sprite = _gameManager.ownedBallSpritesList[i];
            Debug.Log("Inside Loop");
        }
        
        
        // Debug.Log(_gameManager.ownedBallsInt);

        /*for (int i = 0; i <= _gameManager.ownedBallsInt; i++)
        {
            ballPlacments[i].gameObject.SetActive(true);
            ballPlacments[i].GetComponent<SpriteRenderer>().sprite = _gameManager.ownedBallSprites[i];
            Debug.Log(_gameManager.ownedBallsInt);
        }*/
    }
}
