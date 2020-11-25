using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RhythmAudioManager : MonoBehaviour
{
    public static RhythmAudioManager instance = null;
    void Awake()
    {
    
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public AudioSource GetAudioSource()
    {
        return GetComponent<AudioSource>();
    }

    public void PauseAudio()
    {
        GetComponent<AudioSource>().Pause();
    }

    public void UnPauseAudio()
    {
        GetComponent<AudioSource>().UnPause();
    }

}
