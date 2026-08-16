using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyBall : MonoBehaviour
{
    public GameManager _gameManager;
    public Button button;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.money < 20) button.interactable = false;
        if (_gameManager.ownedBallSpritesList.Count >= 5)
        {
            button.interactable = false;
            button.GetComponentInChildren<TMP_Text>().text = "SOLD OUT";
        }
    }

    public void CallBuyBall(Sprite ballSprite)
    {
        if (_gameManager.money >= 20)
        {
            _gameManager.BuyBall(ballSprite);
            _gameManager.money -= 20;
            _gameManager.clownStylePoints++;
            _gameManager._menuManager.clownEnergyPoints--;
            _gameManager._menuManager.ChangedActiveScene(_gameManager.clownGoofinessPoints, _gameManager.clownSkillPoints, _gameManager.clownStylePoints);
        }
        
    }
}
