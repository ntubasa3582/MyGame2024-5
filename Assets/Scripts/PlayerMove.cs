using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GameObject _camera;
    //プレイヤーの移動スピード
    [SerializeField] float _moveSpeed;
    //方向キーの値を保持する変数
    Vector3 _inputDirection;
    //オブジェクトの向きを保持する変数
    Vector3 _forwardDirection;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        SetCameraAngle();
    }
    
    /// <summary></summary>
    void Move()
    {
        _inputDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        if (_inputDirection.magnitude > 0)
        {
            _forwardDirection = this.transform.forward * _inputDirection.x + transform.right * _inputDirection.z;
            _forwardDirection.y = 0;
            _rb.velocity = _forwardDirection * _moveSpeed;
        }
    }
    
    /// <summary>カメラのRotationの値をプレイヤーのRotationの値に代入するメソッド</summary>
    void SetCameraAngle()
    {
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, _camera.transform.localEulerAngles.y,
            transform.eulerAngles.z);
    }
}
