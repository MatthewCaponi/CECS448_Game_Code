using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private int[] numSongs;

    [SerializeField]
    private SongInfoControl songInfo;

    private List<GameObject> songs;

    public string playScene;

    void Start()
    {
        songs = new List<GameObject>();

        //creates buttons for each song
        if (songs.Count > 0)
        {
            foreach (GameObject song in songs)
            {
                Destroy(song.gameObject);
            }

            songs.Clear();
        }

        //Set name for each song in list
        //foreach(int i in numSongs)
        //{
        //    GameObject button = Instantiate(buttonTemplate) as GameObject;
        //    button.SetActive(true);

        //    button.GetComponent<SongListButton>().SetText("Test #" + i);

        //    button.transform.SetParent(buttonTemplate.transform.parent, false);
        //}
    }

    //show song info for clicked song
    public void SongClicked()
    {
        
        songInfo.Load();
    }

    public void Play()
    {
        SceneManager.LoadScene(playScene);
    }

}
