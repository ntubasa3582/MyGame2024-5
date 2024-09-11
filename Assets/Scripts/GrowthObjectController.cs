using UnityEngine;

public class GrowthObjectController : MonoBehaviour //成長するオブジェクトを管理するクラス
{
    [SerializeField] LevelUpTimeValue[] _levelUpTimeValue;
    float _elapsedTime; //経過時間
    int _growthSpeedLevel = 0;            //成長する速さレベル
    int[] _levelUp = new int[4];

    void Awake()
    {
        _levelUp = _levelUpTimeValue[0].LevelUpValue;
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime; //ゲームの経過時間を変数に代入する
        if (_elapsedTime > _levelUpTimeValue[_growthSpeedLevel].LevelUpValue[3])
        {
            ScoreManager.Instance.ScoreValueUp(1); //スコアを1増やす
            _elapsedTime = 0;
            GrowthLevelUp(0, 0); //成長レベル１
        }
        else if (_elapsedTime > _levelUpTimeValue[_growthSpeedLevel].LevelUpValue[2])
        {
            GrowthLevelUp(3, 0.6f); //成長レベル3
        }
        else if (_elapsedTime > _levelUpTimeValue[_growthSpeedLevel].LevelUpValue[1])
        {
            GrowthLevelUp(2, 0.4f); //成長レベル2
        }
        else if (_elapsedTime > _levelUpTimeValue[_growthSpeedLevel].LevelUpValue[0])
        {
            GrowthLevelUp(1, 0.2f); //成長レベル１
        }
    }
    void GrowthLevelUp(int levelValue,float scaleValue)
    {
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}