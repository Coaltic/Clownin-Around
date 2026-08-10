using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject endOfDayMenuPrefab;
    public GameObject endOfDayMenu;
    public GameObject statsPanelPrefab;
    public GameObject statsPanel;

    public TMP_Text visitorNumText;
    public TMP_Text moneyEarnedText;
    public TMP_Text energyText;
    public TMP_Text moneyText;

    public TMP_Text goofyText;
    public TMP_Text skillText;
    public TMP_Text styleText;
    public int clownEnergyPoints;
    public bool UISet;

    public Button bedButton;
    public Button tvButton;
    public Button bookshelfButton;
    public Button computerButton;

    public GameObject blackoutPrefab;

    
    void Start()
    {
        _gameManager = this.transform.parent.GetComponent<GameManager>();  // GameObject.Find("GameManager").GetComponent<GameManager>();
        // endOfDayMenu = GameObject.Find("Menus/EndOfDayRecap Panel");
        Debug.Log(_gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "House" && !UISet)
        { 

            UpdateEnergyandMoney();
            ChangedActiveScene(_gameManager.clownGoofinessPoints, _gameManager.clownSkillPoints, _gameManager.clownStylePoints);
            UISet = true;
        }
    }

    public void ChangedActiveScene(int goofyStat, int skillStat, int styleStat)
    {
        if (statsPanel == null)
        { 
            clownEnergyPoints = 3;
            statsPanel = Instantiate(statsPanelPrefab);
            statsPanel.transform.SetParent(GameObject.Find("UI Canvas").transform, false);
            goofyText = statsPanel.transform.GetChild(0).GetComponent<TMP_Text>();
            skillText = statsPanel.transform.GetChild(1).GetComponent<TMP_Text>();
            styleText = statsPanel.transform.GetChild(2).GetComponent<TMP_Text>();
        }

        goofyText.text = "Goofiness: " + goofyStat;
        skillText.text = "Skill: " + skillStat;
        styleText.text = "Style: " + styleStat;
        if (SceneManager.GetActiveScene().name == "House") UpdateEnergyandMoney();
    }

    public void EndOfWorkDay(int visitors, int money)
    {
        endOfDayMenu = Instantiate(endOfDayMenuPrefab);
        endOfDayMenu.transform.SetParent(GameObject.Find("Menus").transform, false);
        visitorNumText = endOfDayMenu.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>();
        moneyEarnedText = endOfDayMenu.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();

        visitorNumText.text = visitors.ToString();
        moneyEarnedText.text = money.ToString();
    }

    public void GetHouseButtons()
    {
        bedButton = GameObject.Find("UI Canvas/Bed Button").GetComponent<Button>();
        tvButton = GameObject.Find("UI Canvas/TV Button").GetComponent<Button>();
        bookshelfButton = GameObject.Find("UI Canvas/Bookshelf Button").GetComponent<Button>();
        computerButton = GameObject.Find("UI Canvas/Computer Button").GetComponent<Button>();
    }

    public void UpdateEnergyandMoney()
    {
        energyText = GameObject.Find("UI Canvas/Energy Text").GetComponent<TMP_Text>();
        moneyText = GameObject.Find("UI Canvas/Money Text").GetComponent<TMP_Text>();
        energyText.text = "Energy: " + clownEnergyPoints + "/3";
        moneyText.text = "Money: $" + _gameManager.money;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("House");
    }
}
