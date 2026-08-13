using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool startOfDay;
    public bool isDayActive;
    public float dailyTimerMax = 120.0f;
    public float dailyTimer;
    public TMP_Text timerText;
    public TMP_Text moneyText;

    public GameObject clownPrefab;
    public GameObject clownPosition;
    public Clown clown;
    public GameObject menuManagerPrefab;
    public MenuManager _menuManager;

    public GameObject pedestrianPrefab;
    public GameObject leftLoadingZone;
    public GameObject rightLoadingZone;

    public Sprite[] ballSprites;
    public List<Sprite> ownedBallSpritesList;

    public int money;
    public int ownedBallsInt;

    public int dailyMoneyEarned;
    public int dailyVisitorsNum;

    public int clownGoofinessPoints; // determines pedestrians watchtime (giving them a better chance of getting paid)
    public int clownSkillPoints; // determines if pedestrians will want to pay
    public int clownStylePoints; // determines if pedestrians will want to stop

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        startOfDay = true;
    }

    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "BasicStreet" && startOfDay)
        {
            OnDayStart();
            startOfDay = false;
        }

        if (isDayActive)
        {
            DayTimer();
            DeterminePedestrianSpawn();
        }

    }

    public void OnDayStart()
    {
        timerText = GameObject.Find("UI Canvas/Timer Text").GetComponent<TMP_Text>();
        moneyText = GameObject.Find("UI Canvas/Money Text").GetComponent<TMP_Text>();
        leftLoadingZone = GameObject.Find("Left Loading Zone");
        rightLoadingZone = GameObject.Find("Right Loading Zone");

        if (clownPosition == null) clownPosition = GameObject.Find("Clown Position");
        if (_menuManager == null) _menuManager = Instantiate(menuManagerPrefab).GetComponent<MenuManager>();
        _menuManager.transform.SetParent(this.gameObject.transform);
        _menuManager.gameObject.name = "MenuManager";
        clown = Instantiate(clownPrefab).GetComponent<Clown>();
        clown.gameObject.transform.SetParent(clownPosition.transform, false);
        LoadBalls();

        dailyTimer = dailyTimerMax;
        dailyMoneyEarned = 0;
        dailyVisitorsNum = 0;
        isDayActive = true;
        Debug.Log("Goofy: " + clownGoofinessPoints + " Skill: " + clownSkillPoints + " Style: " + clownStylePoints);
        _menuManager.UISet = false;
        _menuManager.ChangedActiveScene(clownGoofinessPoints, clownSkillPoints, clownStylePoints);
    }

    public void EndOfDay()
    {
        isDayActive = false;
        Image sky = GameObject.Find("Background/Sky").GetComponent<Image>();
        sky.color = new Color(0.0f, 0.12f, 0.18f);
        clown.anim.SetTrigger("EndOfDay");

        _menuManager.EndOfWorkDay(dailyVisitorsNum, dailyMoneyEarned);
        /*_menuManager.endOfDayMenu.gameObject.SetActive(true);
        _menuManager.visitorNumText.text = dailyVisitorsNum.ToString();
        _menuManager.moneyEarnedText.text = dailyMoneyEarned.ToString();*/

        //clownGoofinessPoints = clown.goofiness;
        //clownSkillPoints = clown.skill;
        //clownStylePoints = clown.style;

    }

    public void DayTimer()
    {
        dailyTimer -= Time.deltaTime;
        timerText.text = dailyTimer.ToString();
        moneyText.text = "$" + money.ToString();

        if (dailyTimer < 0.0f) EndOfDay();
    }

    public void LoadBalls()
    {
        clown.UpdateBalls();
    }

    public void BuyBall(Sprite ballSprite)
    {
        Debug.Log(ownedBallsInt);
        ownedBallSpritesList.Add(ballSprite);

        //clownSkillPoints++;
        ownedBallsInt++;
    }

    public void DeterminePedestrianSpawn()
    {
        int r = Random.Range(0, 500);

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
