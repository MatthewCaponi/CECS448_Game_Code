using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLevelGameStateManager : MonoBehaviour
{
   public static TopLevelGameStateManager instance = null;

    public enum GameMode { comp, story, none };
    public GameMode gameMode = GameMode.none;

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

   

    
}
