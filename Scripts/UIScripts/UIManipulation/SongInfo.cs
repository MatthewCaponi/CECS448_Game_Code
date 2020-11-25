using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongInfo : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text author;
    [SerializeField]
    private TMP_Text songLength;
    [SerializeField]
    private TMP_Text personalScore;
    [SerializeField]
    private TMP_Text globalScore;
    [SerializeField]
    private Button playButton;

    public void UpdateSongInfo(string name, string artist, string songTime)
    {
        title.text = name;
        author.text = artist;
        songLength.text = songTime;
    }

}
