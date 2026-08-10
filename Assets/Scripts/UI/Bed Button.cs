using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class BedButton : MonoBehaviour
{
    public GameManager _gameManager;
    public MenuManager _menuManager;
    public Button button;
    public GameObject blackoutPrefab;

    public TMP_Text infoText;
    public string infoTextString;
    public int cost = 0;

    void Update()
    {
        if (button == null) button = this.gameObject.GetComponent<Button>();
        if (infoTextString == "") infoTextString = "Go to bed for the night";
        if (infoText == null) infoText = GameObject.Find("UI Canvas/Info Text").GetComponent<TMP_Text>();
        if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_menuManager == null) _menuManager = GameObject.Find("GameManager/MenuManager").GetComponent<MenuManager>();

    }

    public void OnMouseOver()
    {
        infoText.text = infoTextString;
        Debug.Log("Bed");
    }

    public void OnClickBed()
    {
        Instantiate(blackoutPrefab, GameObject.Find("UI Canvas").transform, false);
        _gameManager.startOfDay = true;
        
    }
}
