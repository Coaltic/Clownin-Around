using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blackout : MonoBehaviour
{
    public Image image;
    public float timerMax;
    public float timer;
    public bool fadeoutDone;

    void Start()
    {
        image = this.GetComponent<Image>();
        timerMax = 1.0f;
        timer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {

        Color c = image.color;
        c.a += 0.01f;
        image.color = c;

        if (c.a > 1)
        {
            fadeoutDone = true;
        }

        if (fadeoutDone)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) SceneManager.LoadScene("BasicStreet");
        }
    }
}
