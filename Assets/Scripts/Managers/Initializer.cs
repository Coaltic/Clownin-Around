using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameObject _gameManagerPrefab;
    public GameObject _gameManager;


    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager");
        if (_gameManager == null)
        {
            _gameManager = Instantiate(_gameManagerPrefab);
            _gameManager.name = "GameManager";
        }
        
        Destroy(this.gameObject);
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
