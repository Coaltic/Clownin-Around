using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject endOfDayMenu;
    public TMP_Text visitorNumText;
    public TMP_Text moneyEarnedText;

    public TMP_Text goofyText;
    public TMP_Text skillText;
    public TMP_Text styleText;

    public GameObject blackoutPrefab;


    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        goofyText.text = "Goofiness: " + _gameManager.clown.goofiness;
        skillText.text = "Skill: " + _gameManager.clown.skill;
        styleText.text = "Style: " + _gameManager.clown.style;
    }

    // Update is called once per frame
    void Update()
    {

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
