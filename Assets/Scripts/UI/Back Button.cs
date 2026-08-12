using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject computerScreen;

    public Button bedButton;
    public Button tvButton;
    public Button bookshelfButton;
    public Button computerButton;

    public void OnClick()
    {
        computerScreen.SetActive(false);
        bedButton.gameObject.SetActive(true);
        tvButton.gameObject.SetActive(true);
        bookshelfButton.gameObject.SetActive(true);
        computerButton.gameObject.SetActive(true);
    }
}
