using UnityEngine;
using UnityEngine.UI;

public class AlertButton : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject computerCanvas;

    void Start()
    {
        if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.money >= 250 && !_gameManager.trophyObtained)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponent<Button>().enabled = true;
        }
    }

    public void OnClickAlert()
    {
        computerCanvas.SetActive(true);

        computerCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        computerCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        _gameManager.trophyObtained = true;
    }

    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
        computerCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        computerCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        computerCanvas.SetActive(false);
    }
}
