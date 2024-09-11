using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance => _instance;
    static ScoreManager _instance;
    public int Score { get; private set; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<ScoreManager>();
            _instance = this;
        }
    }

    public void ScoreValueUp(int value)
    {
        Score += value;
        Debug.Log("現在のスコアは" + Score + "です");
    }
}
