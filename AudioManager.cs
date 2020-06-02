//==================
//直接在unity的属性面板中配置audioLists列表即可在代码的任何地方通过调用PlayAudio(string audioName)方法来播放声音
//==================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct AudioData
{
    public string audioName;
    public AudioClip audioClip;
}

/// <summary>
/// 音效管理器
/// </summary>
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    public List<AudioData> audioLists;
    private AudioSource audioSource;

    private Dictionary<string, AudioClip> audioDics = new Dictionary<string, AudioClip>();

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < audioLists.Count; i++)
        {
            audioDics.Add(audioLists[i].audioName, audioLists[i].audioClip);
        }
    }

    /// <summary>
    /// 播放声音
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayAudio(string audioName)
    {
        audioSource.PlayOneShot(audioDics[audioName]);
    }
}
