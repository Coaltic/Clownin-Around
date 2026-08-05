using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isDayActive;
    public float dailyTimerMax = 120.0f;
    public float dailyTimer;
    public TMP_Text timerText;
    public TMP_Text moneyText;

    public GameObject clownPrefab;
    public GameObject clownPosition;
    public Clown clown;
    public MenuManager _menuManager;

    public GameObject pedestrianPrefab;
    public GameObject leftLoadingZone;
    public GameObject rightLoadingZone;

    public Sprite[] ballSprites;
    public Sprite[] ownedBallSprites;

    public int money;
    public int ownedBallsInt = 0;

    public int dailyMoneyEarned;
    public int dailyVisitorsNum;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        ownedBallSprites = new Sprite[ballSprites.Length];
        if (clownPosition == null) clownPosition = GameObject.Find("Clown Position");
        _menuManager = this.gameObject.GetComponentInChildren<MenuManager>();
        clown = Instantiate(clownPrefab).GetComponent<Clown>();
        clown.gameObject.transform.SetParent(clownPosition.transform, false);
        Debug.Log(ownedBallsInt);
        BuyBall(ballSprites[0]);
        OnDayStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDayActive)
        {
            DayTimer();
            DeterminePedestrianSpawn();
        }
    }

    public void OnDayStart()
    {
        dailyTimer = dailyTimerMax;
        dailyMoneyEarned = 0;
        dailyVisitorsNum = 0;
        isDayActive = true;
    }

    public void EndOfDay()
    {
        isDayActive = false;
        Image sky = GameObject.Find("Background/Sky").GetComponent<Image>();
        sky.color = new Color(0.0f, 0.12f, 0.18f);
        clown.anim.SetTrigger("EndOfDay");

        _menuManager.endOfDayMenu.gameObject.SetActive(true);
        _menuManager.visitorNumText.text = dailyVisitorsNum.ToString();
        _menuManager.moneyEarnedText.text = dailyMoneyEarned.ToString();

    }

    public void DayTimer()
    {
        dailyTimer -= Time.deltaTime;
        timerText.text = dailyTimer.ToString();
        moneyText.text = "$" + money.ToString();

        if (dailyTimer < 0.0f) EndOfDay();
    }

    public void BuyBall(Sprite ballSprite)
    {
        Debug.Log(ownedBallsInt);
        ownedBallSprites[ownedBallsInt] = ballSprite;
        
        clown.UpdateBalls();
        ownedBallsInt++;
    }

    public void DeterminePedestrianSpawn()
    {
        int r = Random.Range(0, 600);

        if (r == 1)
        {
            SpawnPedestrian();
        }
    }

    public void SpawnPedestrian()
    {
        GameObject pedestrian = Instantiate(pedestrianPrefab);
        int rndSide = Random.Range(1, 3);
        if (rndSide == 1) // spawns on the left
        {
            // Debug.Log("Pedestrian has spawned on the left side");
            pedestrian.GetComponent<Pedestrian>().facingLeft = false;
            pedestrian.transform.position = leftLoadingZone.transform.position;
        }
        if (rndSide == 2) // spawns on the right
        {
            pedestrian.GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
            pedestrian.GetComponent<Pedestrian>().facingLeft = true;
            pedestrian.transform.position = rightLoadingZone.transform.position;
        }
    }
}
