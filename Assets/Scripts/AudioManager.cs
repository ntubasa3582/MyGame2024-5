using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour       //サウンドとSEを管理するクラス
{
    [SerializeField] AudioSource _bgmAudioSource;
    [SerializeField] AudioClip[] _bgmClip;
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioSource[] _seAudioSources;
    [SerializeField] AudioClip[] _seClip;
    float _bgmVolume;
    float _seVolume;
    void Start()
    {
        _audioMixer.SetFloat("StageBGM", -20);
        
    }

    public void BGMVolumeChange(float value)
    {
        _audioMixer.SetFloat("StageBGM", value);
    }
    
}