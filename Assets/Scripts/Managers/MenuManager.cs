using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject endOfDayMenu;
    public GameObject statsPanelPrefab;
    public GameObject statsPanel;

    public TMP_Text visitorNumText;
    public TMP_Text moneyEarnedText;

    public TMP_Text goofyText;
    public TMP_Text skillText;
    public TMP_Text styleText;

    public GameObject blackoutPrefab;

    
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Running On Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        //ChangedActiveScene();
    }

    public void ChangedActiveScene()
    {
        statsPanel = Instantiate(statsPanelPrefab);
        statsPanel.transform.SetParent(GameObject.Find("UI Canvas").transform, false);
        goofyText = statsPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        skillText = statsPanel.transform.GetChild(1).GetComponent<TMP_Text>();
        styleText = statsPanel.transform.GetChild(2).GetComponent<TMP_Text>();

        //goofyText.text = "Goofiness: " + _gameManager.clown.goofiness;
        //skillText.text = "Skill: " + _gameManager.clown.skill;
        //styleText.text = "Style: " + _gameManager.clown.style;
    }

    public void OnClickGoHome()
    {
        SceneManager.LoadScene("House");
    }

    public void OnClickBed()
    {
        Instantiate(blackoutPrefab, GameObject.Find("Canvas").transform, false);
    }
}
