using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTimingController : MonoBehaviour
{
    private float beatTiming;
 
    private float beatOffset;
    private float secOffset;
    private float beatFactor;
    private float spawnFactor;
    public static BeatTimingController instance;

    public float BeatTiming { get => beatTiming; set => beatTiming = value; }
    public float BeatOffset { get => beatOffset; set => beatOffset = value; }
    public float SecOffset { get => secOffset; set => secOffset = value; }
    public float BeatFactor { get => beatFactor; set => beatFactor = value; }
    public float SpawnFactor { get => spawnFactor; set => spawnFactor = value; }

    private void Awake()
    {
        instance = this;
        Debug.Log("Analyzing");
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            switch (SongAnalyzer.instance.songState)
            {
                case SongState.slow:
                    BeatFactor = 4000;
                    SpawnFactor = 5;
                    break;

                case SongState.slowBuildUp:
                    if (BeatFactor > 2500 && spawnFactor > 3)
                    {
                        BeatFactor -= (.5f * Time.deltaTime);
                        SpawnFactor -= (.25f * Time.deltaTime);
                    }
                    break;

                case SongState.buildUp:
                    if (BeatFactor > 2500 && spawnFactor > 2)
                    {
                        BeatFactor -= (1 * Time.deltaTime);
                        SpawnFactor -= (.5f * Time.deltaTime);
                    }
                    break;

                case SongState.fast:
                    BeatFactor = 1;
                    break;

                case SongState.fastTransition:
                    if (BeatFactor > 2200 && spawnFactor > 2)
                    {
                        BeatFactor -= (5 * Time.deltaTime);
                        SpawnFactor -= (.5f * Time.deltaTime);
                    }

                    break;

                case SongState.pause:
                    BeatFactor = 6000;
                    SpawnFactor = 7;
                    break;

                case SongState.slowSteady:
                    BeatFactor = 3000;
                    SpawnFactor = 5;
                    break;

                case SongState.fastSteady:
                    BeatFactor = 2200;
                    SpawnFactor = 3;
                    break;

                // This will 100% need to be changed
                case SongState.finish:
                    BeatFactor = 3000;
                    SpawnFactor = 1;
                    break;


            }
        }
        
    }
}
