using UnityEngine;

public class PlantController : MonoBehaviour
{
    MeshFilter _meshFilter;
    [SerializeField] Mesh[] _meshes;
    float _elapsedTime;                     //経過時間
    float _growthLevel;                     //オブジェクトの成長レベルを表す変数
    void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        transform.localRotation = Quaternion.AngleAxis(Random.Range(0,365),Vector3.up);
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;         //ゲームの経過時間を変数に代入する
        switch (_elapsedTime)                   //経過時間に応じてオブジェクトの見た目を変更する
        {
            case > 20:
                //実のらせる
                break;
            case > 15:
                MeshChange(2);  //Lサイズ
                break;
            case >10:
                MeshChange(1);  //Mサイズ
                break;
            case >5:
                MeshChange(0);  //Sサイズ
                break;
        }
    }
    //オブジェクトのメッシュと_growthLevel変数の値を変更するメソッド

    void MeshChange(int meshCount)
    {
        if (_meshes[meshCount] != null)
        {
            _meshFilter.mesh = _meshes[meshCount];   
        }
        _growthLevel = meshCount + 1;
    }
    
}
