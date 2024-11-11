using UnityEngine;
using Cinemachine;
public class VartualCameraController : MonoBehaviour
{
    /// <summary>バーチャルカメラ</summary>
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [Header("バーチャルカメラの水平方向への移動感度")]
    [SerializeField] float _xSensitivity = 300;
    [Header("バーチャルカメラの垂直方向への移動感度")]
    [SerializeField] float _ySensitivity = 300;

    private void Awake()
    {
        //バーチャルカメラのPOVを取得
        var virtualCameraPov = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        //VerticalAxisのスピードパラメータに変数を代入
        virtualCameraPov.m_VerticalAxis.m_MaxSpeed = _xSensitivity;
        //HorizontalAxisのスピードパラメータに変数を代入
        virtualCameraPov.m_HorizontalAxis.m_MaxSpeed = _ySensitivity;
    }
}
