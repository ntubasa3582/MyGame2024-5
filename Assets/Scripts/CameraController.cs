using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour //カメラの移動制御スクリプト
{
    Camera _mainCamera;

    [FormerlySerializedAs("_limitObj")] [FormerlySerializedAs("_moveLimitObj")] [SerializeField]
    GameObject[] _moveLimitPoint; //カメラの移動の制限座標のオブジェクト

    GameObject _followObj; //カメラが正面に移すオブジェクト

    [FormerlySerializedAs("_cameraSpeed")] [SerializeField]
    float _moveSpeed; //カメラスピード

    Vector3 _cameraMoveLimit;
    Vector3 _mouseVector; //マウスの座標の変数
    float _mouseScrollValue; //マウスホイールの入力時の値を入れる変数

    void Start()
    {
        _followObj = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(_followObj.transform.position.x, 15f, _followObj.transform.position.z + -7.5f);
        transform.rotation = Quaternion.Euler(60, 0, 0);
        _mainCamera = Camera.main;
        _mainCamera.fieldOfView = 70;
    }


    void Update()
    {
        _mouseScrollValue = -1 * Input.mouseScrollDelta.y; //マウスホイールの入力値を変数に入れる    -1をかけて値を逆にする
        _mainCamera.fieldOfView += _mouseScrollValue;
        _mainCamera.fieldOfView = Mathf.Clamp(_mainCamera.fieldOfView, 50, 80);
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _moveLimitPoint[1].transform.position.x,
                _moveLimitPoint[0].transform.position.x),
            15,
            Mathf.Clamp(transform.position.z, _moveLimitPoint[1].transform.position.z,
                _moveLimitPoint[0].transform.position.z)
        );

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0)) //左クリックでカメラの移動
        {
            _mouseVector =
                new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y")); //マウスの移動量を変数に代入する
            transform.position += _mouseVector * (_moveSpeed * 0.005f); //移動量にTime.deltaTimeをかけてtransformに代入する
            Cursor.visible = false; //マウスカーソルの表示をオフにする
        }
        else
        {
            Cursor.visible = true; //マウスカーソルの表示をオンにする
        }

        if (Input.GetButton("Jump")) //Spaceキーが押されたらtargetの位置にカメラを固定する
        {
            transform.position =
                new Vector3(_followObj.transform.position.x, 15f, _followObj.transform.position.z + -7.5f);
        }
    }
}