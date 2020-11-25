using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicManager : MonoBehaviour
{
    public static GameMusicManager instance = null;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name.ToString());

        if (SceneManager.GetActiveScene().name.ToString() == "IntroScene" || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainGameScene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainGame2"))
        {
            GetComponent<AudioSource>().Stop();
            Destroy(this.gameObject);
        }
    }
    // any other methods you need
}
