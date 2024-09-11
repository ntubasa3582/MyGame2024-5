using UnityEngine;
public class FieldSpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] _fieldObj;
    int _xPos = -4;
    int _zPos = -7;

    void Awake()
    {
        SpawnField(0);
    }

    public void SpawnField(int fieldObjectCount)
    {
        if (_zPos != 8)
        {
            Instantiate(_fieldObj[fieldObjectCount], new Vector3(_xPos, 0, _zPos), Quaternion.identity);
            _zPos += 1;
        }
        else
        {
            _zPos = -7;
            _xPos += 1;
            Instantiate(_fieldObj[fieldObjectCount], new Vector3(_xPos, 0, _zPos), Quaternion.identity);
            _zPos += 1;
        }
    }
}
