using UnityEngine;
using UnityEngine.UI;
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

    public Sprite[] ballSprites;
    public Sprite[] ownedBallSprites;

    public int money;
    public int ownedBallsInt = 0;

    void Start()
    {
        ownedBallSprites = new Sprite[ballSprites.Length];
        if (clownPosition == null) clownPosition = GameObject.Find("Clown Position");
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
        }
    }

    public void OnDayStart()
    {
        dailyTimer = dailyTimerMax;
        
        isDayActive = true;
    }

    public void EndOfDay()
    {
        isDayActive = false;
        Image sky = GameObject.Find("Background/Sky").GetComponent<Image>();
        sky.color = new Color(0.0f, 0.12f, 0.18f);
        clown.anim.SetTrigger("EndOfDay");
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
        /*for (int i = 0; i < ownedBallsInt; i++)
        {
            clown.ballsArray[i].SetActive(true);
            clown.ballsArray[i].SetActive(true);
        }*/
    }
}
