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
        _gameManager = this.transform.parent.GetComponent<GameManager>();  // GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Running On Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        //ChangedActiveScene();
    }

    public void ChangedActiveScene(int goofyStat, int skillStat, int styleStat)
    {
        statsPanel = Instantiate(statsPanelPrefab);
        statsPanel.transform.SetParent(GameObject.Find("UI Canvas").transform, false);
        goofyText = statsPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        skillText = statsPanel.transform.GetChild(1).GetComponent<TMP_Text>();
        styleText = statsPanel.transform.GetChild(2).GetComponent<TMP_Text>();

        goofyText.text = "Goofiness: " + goofyStat;
        skillText.text = "Skill: " + skillStat;
        styleText.text = "Style: " + styleStat;
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
