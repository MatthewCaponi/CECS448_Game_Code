using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SongListButton : MonoBehaviour
{

    [SerializeField]
    private TMP_Text myText;
    [SerializeField]
    private SongListControl songControl;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI authorText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] string scenePlay;
    [SerializeField] GameObject songScroll;
    [SerializeField] GameObject songInfo;


    [SerializeField] string name;
    [SerializeField] string author;
    [SerializeField] string time;

    private string myTextString;

    public void SetText()
    {
        songInfo.SetActive(true);
        titleText.text = name;
        authorText.text = author;
        timeText.text = time;

        songScroll.GetComponent<SongListControl>().playScene = (scenePlay);
    }

    public void Play()
    {
        SceneManager.LoadScene(scenePlay);
    }

}
