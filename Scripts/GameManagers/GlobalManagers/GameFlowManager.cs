using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] int level;
    bool started = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameMusicManager.instance != null)
        {
            Destroy(GameMusicManager.instance.gameObject);
        }
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CALLING UPDATE");
        if (PlayerStateController.instance.state == PlayerStateController.PlayerState.dead)
        {
            TopLevelGameStateManager.GameMode gameMode = TopLevelGameStateManager.instance.gameMode;

            if (level == 1)
            {
                Invoke("GameOverLevel1", 2f);
            }
            else if (level == 2)
            {
                Invoke("GameOverLevel2", 2f);
            }         
        }
        else if (PlayerStateController.instance.state == PlayerStateController.PlayerState.victory)
        {
            started = true;
            TopLevelGameStateManager.GameMode gameMode = TopLevelGameStateManager.instance.gameMode;
            if (gameMode == TopLevelGameStateManager.GameMode.story)
            {
                if (level == 1)
                {
                    Invoke("StoryModeLevel1Victory", 5f);
                }
                else if (level == 2)
                {
                    Invoke("StoryModeLevelTwoVictory", 5f);
                }
            }
            else if (gameMode == TopLevelGameStateManager.GameMode.comp)
            {
                if (level == 1)
                {
                    Invoke("CompModeLevel1Victory", 5f);
                }
                else if (level == 2)
                {
                    Invoke("CompModeLevel2Victory", 5f);
                }
            }
            
            
        }
    }

    private void GameOverLevel1()
    {
        SceneManager.LoadScene("GameOverLevel1");
    }

    private void GameOverLevel2()
    {
        SceneManager.LoadScene("GameOverLevel2");
    }

    private void StoryModeLevel1Victory()
    {
        SceneManager.LoadScene("StoryModeLevel1Victory");
    }

    private void StoryModeLevelTwoVictory()
    {
        SceneManager.LoadScene("StoryModeLevelTwoVictory");
    }

    private void CompModeLevel1Victory()
    {
        SceneManager.LoadScene("CompModeLevel1Victory");
    }

    private void CompModeLevel2Victory()
    {
        SceneManager.LoadScene("CompModeLevel2Victory");
    }
}
