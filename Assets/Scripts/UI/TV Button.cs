using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class TVButton : MonoBehaviour
{
    public GameManager _gameManager;
    public MenuManager _menuManager;
    public Button button;
    public TMP_Text infoText;
    public string infoTextString;
    public int cost = 5;


    // Update is called once per frame
    void Update()
    {
        if (button == null) button = this.gameObject.GetComponent<Button>();
        if (infoTextString == "") infoTextString = "$5: Watch a Pay-Per-View clown event to raise your goofiness";
        if (infoText == null) infoText = GameObject.Find("UI Canvas/Info Text").GetComponent<TMP_Text>();
        if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_menuManager == null) _menuManager = GameObject.Find("GameManager/MenuManager").GetComponent<MenuManager>();

        

        if (_gameManager.money < cost || _menuManager.clownEnergyPoints <= 0) button.interactable = false;
    }

    public void OnMouseOver()
    {
        infoText.text = infoTextString;
    }

    public void OnClickTV()
    {
        _gameManager.money -= cost;
        _gameManager.clownGoofinessPoints++;
        _menuManager.clownEnergyPoints--;
        _menuManager.ChangedActiveScene(_gameManager.clownGoofinessPoints, _gameManager.clownSkillPoints, _gameManager.clownStylePoints);
    }

}
