using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance => _instance;
    [SerializeField] Text _scoreText;       //スコアを表示するテキスト
    public int Score => _score;             //スコアを記録する変数
    private int _score;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<ScoreManager>();
            _instance = this;
        }
        ScoreTextRewrite();
    }

    /// <summary>_scoreの値を変える変数</summary>
    public void ScoreValueChange(int value)
    {
        _score += value;        //値を変える
        ScoreTextRewrite();
    }

    /// <summary>スコアテキストの値を最新にする</summary>
    void ScoreTextRewrite()
    {
        _scoreText.text = _score.ToString();
    }
}
