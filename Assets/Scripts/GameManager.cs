using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Instance => _instance;
    // public event Action<bool> GameStart;        //デリゲート
    public bool GameStart { get;private set; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<GameManager>();
            _instance = this;
        }
    }

    public void GameStartValueChange(bool value)
    {
        GameStart = value;
    }
}
