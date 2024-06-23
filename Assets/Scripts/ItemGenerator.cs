using UnityEngine;
public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _itemObjects;     //アイテムのプレハブ
    [SerializeField] GameObject _startPos;          //スタート地点のオブジェクト
    [SerializeField] GameObject _goalPos;           //ゴール地点のオブジェクト
    float _stageLength;                             //ステージの長さを入れる変数
    int _randomMemory;                              //ランダムな値を保存する変数
    int _xValue;                                    //ランダムな座標を入れる変数
    void Awake()
    {
        _stageLength = _goalPos.transform.position.z - _startPos.transform.position.z;
        for (int i = 0; i < (int) _stageLength; i++)
        {
            if (i % 7 == 0 && i != 0)
            {
                Instantiate(_itemObjects[0], new Vector3(RandomItemPos(), 1, i), Quaternion.identity);
            }
        }
    }
    /// <summary>ｘ座標を３つの値からランダムな値を返すメソッド</summary>
    /// <returns>変えたい座標の値を返す</returns>
    int RandomItemPos()
    {
        int itemXpos = 0;
        itemXpos = Random.Range(0, 3);
        //連続で同じ場所にならないように再抽選を行う
        while (true)
        {
            //違う値だったらwhileを抜ける
            if (_randomMemory != itemXpos)
            {
                break;
            }
            itemXpos = Random.Range(0, 3);
        }
        _randomMemory = 0;
        //数値を変える
        switch (itemXpos)
        {
            case 0:
                _xValue = -5;
                break;
            case 1:
                _xValue = 0;
                break;
            case 2:
                _xValue = 5;
                break;
        }
        //Random.Rangeで与えられた数値を別の変数で保存する
        _randomMemory = itemXpos;
        return _xValue;
    }
}
