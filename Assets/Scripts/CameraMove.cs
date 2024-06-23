using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMove : MonoBehaviour         //カメラの移動を制御するスクリプト
{
    [SerializeField] GameObject _player;
    bool _isMoveStop;
    
    void Update()
    {
        //プレイヤーを追いかける
        transform.position = new Vector3(transform.position.x, 10.27f, _player.transform.position.z -11);
    }
}
