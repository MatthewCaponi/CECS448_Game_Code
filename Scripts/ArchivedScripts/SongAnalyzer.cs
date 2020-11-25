using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongAnalyzer : MonoBehaviour
{
    public SongState songState;
    [SerializeField] AudioSource music;
    public static SongAnalyzer instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        songState = SongState.slow;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!PauseMenu.IsPaused)
        {
            if (music.time > 0 && music.time < 14.5)
            {
                songState = SongState.slow;

            }
            else if (music.time >= 15.5 && music.time < 24.5)
            {
                songState = SongState.buildUp;
            }
            else if (music.time >= 24.5 && music.time < 26.5)
            {
                songState = SongState.pause;
            }
            else if (music.time >= 26.5 && music.time < 36)
            {
                songState = SongState.fastTransition;
            }
            else if (music.time >= 36 && music.time < 62)
            {
                songState = SongState.fastSteady;
            }
            else if (music.time >= 62 && music.time < 65)
            {
                songState = SongState.fastTransition;
            }
            else if (music.time >= 65 && music.time < 75)
            {
                songState = SongState.fastSteady;
            }
            else if (music.time >= 75 && music.time < 82)
            {
                songState = SongState.pause;
            }
            else if (music.time >= 82 && music.time < 98)
            {
                songState = SongState.slowBuildUp;
            }
            else if (music.time >= 98 && music.time < 123)
            {
                songState = SongState.slowSteady;
            }
            else if (music.time >= 123 && music.time < 126)
            {
                songState = SongState.pause;
            }
            else if (music.time >= 126 && music.time < 132)
            {
                songState = SongState.buildUp;
            }
            else if (music.time >= 132 && music.time < 139)
            {
                songState = SongState.fastTransition;
            }
            else if (music.time >= 139 && music.time < 160)
            {
                songState = SongState.fastSteady;
            }
            else if (music.time >= 160 && music.time < 172)
            {
                songState = SongState.fastSteady;
            }
            else if (music.time >= 172)
            {
                songState = SongState.finish;
            }
        }
        
    }
}

public enum SongState
{
    slow,
    slowBuildUp,
    slowSteady,
    fast,
    buildUp,
    fastTransition,
    pause,
    fastSteady,
    finish
}
