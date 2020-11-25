using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SongInfoControl : MonoBehaviour
{
    [SerializeField]
    private GameObject songInfoTemplate;

    [SerializeField]
    private GameObject current;
    private int songId;

    public void Load()
    {
        current = songInfoTemplate;
        current.SetActive(true);
    }

    public void PlaySong()
    {
        SceneManager.LoadScene("ClassSelection");

    }

    public void getInfo()
    {
        songId = 2;
    }
}
