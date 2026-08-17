using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ComputerButton : MonoBehaviour
{
    public GameManager _gameManager;
    public MenuManager _menuManager;
    public Button button;
    public TMP_Text infoText;
    public string infoTextString;

    public GameObject computerScreen;
    public Button bedButton;
    public Button tvButton;
    public Button bookshelfButton;
    public Button computerButton;


    // Update is called once per frame
    void Update()
    {
        if (button == null) button = this.gameObject.GetComponent<Button>();
        if (infoTextString == "") infoTextString = "Order new equipment to boost your appeal and style";
        if (infoText == null) infoText = GameObject.Find("UI Canvas/Info Text").GetComponent<TMP_Text>();
        if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_menuManager == null) _menuManager = GameObject.Find("GameManager/MenuManager").GetComponent<MenuManager>();

        if (_menuManager.clownEnergyPoints <= 0) button.interactable = false;
        if (_gameManager.money >= 250 && !_gameManager.trophyObtained) button.interactable = false;

    }

    public void OnMouseOver()
    {
        infoText.text = infoTextString;
    }

    public void OnClickComputer()
    {
        computerScreen.SetActive(true);
        bedButton.gameObject.SetActive(false);
        tvButton.gameObject.SetActive(false);
        bookshelfButton.gameObject.SetActive(false);
        computerButton.gameObject.SetActive(false);

    }
}
