using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMove : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトの移動パラメータ"), Range(1, 7)] float _moveSpeed;
    Rigidbody _rb;
    Transform _transform;
    /// <summary>現在のレーンの場所を記録する変数</summary>
    float _moveLaneIndex = 1;
    /// <summary>trueなら動きを止める。falseなら直線移動をする</summary>
    bool _isMoveStop;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _moveLaneIndex = Mathf.Clamp(_moveLaneIndex, 0, 2);
        if (!_isMoveStop)
        {
            _rb.velocity = new Vector3(0, 0, _moveSpeed * 3);
        }
        Debug.Log(_moveLaneIndex);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //左矢印またはAキーが押されたら数値をマイナス１する
            _moveLaneIndex -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //右矢印またはDキーが押されたら数値をプラス１する
            _moveLaneIndex += 1;
        }

        switch (_moveLaneIndex)
        {
            case 0:
                _transform.position = new Vector3(-5, transform.position.y, transform.position.z);
                break;
            case 1:
                _transform.position = new Vector3(0, transform.position.y, transform.position.z);
                break;
            case 2:
                _transform.position = new Vector3(5, transform.position.y, transform.position.z);
                break;
        }
    }
}