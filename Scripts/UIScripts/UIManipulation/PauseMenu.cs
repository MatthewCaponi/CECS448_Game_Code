using System.Collections;
using System.Collections.Generic;

using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseUI;
    public GameObject optionsUI;
    public AudioSource audioManager;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        optionsUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        audioManager.UnPause();
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        audioManager.Pause();
    }

    public void OpenOptionsMenu()
    {
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void QuitSong()
    {
        Resume();
        SceneManager.LoadScene("SongMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
