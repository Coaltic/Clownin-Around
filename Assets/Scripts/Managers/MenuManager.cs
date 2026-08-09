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
    public TMP_Text energyText;

    public TMP_Text goofyText;
    public TMP_Text skillText;
    public TMP_Text styleText;
    public int clownEnergyPoints;
    public bool energySet;

    public Button bedButton;
    public Button tvButton;
    public Button bookshelfButton;
    public Button computerButton;

    public GameObject blackoutPrefab;

    
    void Start()
    {
        _gameManager = this.transform.parent.GetComponent<GameManager>();  // GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Running On Start");
        Debug.Log(SceneManager.GetActiveScene().name);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "House" && !energySet)
        { 
            UpdateEnergy();
            energySet = true;
        }
    }

    public void ChangedActiveScene(int goofyStat, int skillStat, int styleStat)
    {
        clownEnergyPoints = 3;
        statsPanel = Instantiate(statsPanelPrefab);
        statsPanel.transform.SetParent(GameObject.Find("UI Canvas").transform, false);
        goofyText = statsPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        skillText = statsPanel.transform.GetChild(1).GetComponent<TMP_Text>();
        styleText = statsPanel.transform.GetChild(2).GetComponent<TMP_Text>();

        goofyText.text = "Goofiness: " + goofyStat;
        skillText.text = "Skill: " + skillStat;
        styleText.text = "Style: " + styleStat;
    }

    public void GetHouseButtons()
    {
        bedButton = GameObject.Find("Canvas/Bed Button").GetComponent<Button>();
        tvButton = GameObject.Find("Canvas/TV Button").GetComponent<Button>();
        bookshelfButton = GameObject.Find("Canvas/Bookshelf Button").GetComponent<Button>();
        computerButton = GameObject.Find("Canvas/Computer Button").GetComponent<Button>();
    }

    public void UpdateEnergy()
    {
        energyText = GameObject.Find("Canvas/Energy Text").GetComponent<TMP_Text>();
        energyText.text = "Energy: " + clownEnergyPoints + "/3";
    }

    public void OnClickGoHome()
    {
        SceneManager.LoadScene("House");
    }

    public void OnClickBed()
    {
        Instantiate(blackoutPrefab, GameObject.Find("Canvas").transform, false);
    }

    public void OnClickTV()
    {

    }

    public void OnClickBookshelf()
    {

    }

    public void OnClickComputer()
    {

    }
}
