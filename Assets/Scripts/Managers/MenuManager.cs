using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject endOfDayMenu;
    public TMP_Text visitorNumText;
    public TMP_Text moneyEarnedText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGoHome()
    {
        SceneManager.LoadScene("House");
    }
}
