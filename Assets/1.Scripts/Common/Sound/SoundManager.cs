using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource[] audioSources;
    public SoundInfo[] soundInfos;
    // list 느ㄴ 크긱ㅏ 유동적이다 근ㅔ 배열은 Array는  크ㄱㅣ가 고정적이다
    void Start()
    {
        soundInfos = Resources.LoadAll<SoundInfo>("Sound");
    }
   void Awake()
{
    Instance = this;
    DontDestroyOnLoad(gameObject);

    soundInfos = Resources.LoadAll<SoundInfo>("Sound");

    audioSources = new AudioSource[20];
    for (int i = 0; i < 20; i++)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSources[i] = audioSource;
        audioSources[i].playOnAwake = false;
        audioSources[i].loop = false;
    }
}

    public void PlaySound(SoundType type)
    {
        SoundInfo info = null;
        for (int i = 0; i < soundInfos.Length; i++)
        {
            if (soundInfos[i].soundType == type)
            {
                info = soundInfos[i];
                break;
            }

        }
      AudioSource audio =   GetAudioSource();
      audio.clip = info.clip;
      audio.Play();

    }

   AudioSource GetAudioSource()
{
    for (int i = 0; i < audioSources.Length; i++)
    {
        if (!audioSources[i].isPlaying)
            return audioSources[i];
    }
    return audioSources[0]; // 거의 그런 일 없지만 전부 재생 중이면 첫 번째 사용
}

}
