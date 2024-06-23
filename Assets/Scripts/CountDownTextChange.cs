using UnityEngine;
using UnityEngine.UI;

public class CountDownTextChange : MonoBehaviour        //カウントダウンテキストを管理するクラス
{
    [SerializeField] Text _countDownText;       //カウントダウンテキスト
    Animator _animator;

    void Awake()
    {
        _countDownText.enabled = true;
    }

    void TextValueChange(string value)
    {
        _countDownText.text = value;
    }

    void GameStart()
    {
        GameManager.Instance.GameStartValueChange(true);        //ゲームをスタートする
        _countDownText.enabled = false;
    }
}