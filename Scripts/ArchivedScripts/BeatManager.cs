using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    //beats per minute
    [SerializeField] float bpm;

    //how many seconds occur in each beat
    private float secPerBeat;

    //current song position, in seconds
    private float songPosition;

    //current song position, in beats
    private float songPositionBeats;

    //how long since song started
    private float secsSinceStart;

    //offset to the actual start of the song
    [SerializeField] float songStartOffset;

    [SerializeField] float secsInSong;

    private float beatsPerSong;

    private float beatSongPercent = 0;

    public static BeatManager instance;

 

    //audio source
    public AudioSource music;

    public float Bpm { get => bpm; set => bpm = value; }
    public float SecPerBeat { get => secPerBeat; set => secPerBeat = value; }
    public float SongPositionBeats { get => songPositionBeats; set => songPositionBeats = value; }
    public float SecsSinceStart { get => secsSinceStart; set => secsSinceStart = value; }
    public float SongStartOffset { get => songStartOffset; set => songStartOffset = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //music = GetComponent<AudioSource>();

        SecPerBeat = 60f / Bpm;

        SecsSinceStart = (float)AudioSettings.dspTime;

        secsInSong = music.clip.length;

        beatsPerSong = secsInSong / SecPerBeat;

        music.Play();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!PauseMenu.IsPaused)
        {
            //how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - SecsSinceStart - SongStartOffset);

            //convert song position to beats
            SongPositionBeats = songPosition / SecPerBeat;

            beatSongPercent = SongPositionBeats / beatsPerSong;
        }
     
    }
}
