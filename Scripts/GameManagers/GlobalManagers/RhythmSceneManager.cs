using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameSceneProj2");
    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }


}
