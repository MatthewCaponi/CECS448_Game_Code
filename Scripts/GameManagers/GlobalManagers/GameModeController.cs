using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetGameModeToStory()
    {
        TopLevelGameStateManager.instance.gameMode = TopLevelGameStateManager.GameMode.story;
    }
    public void SetGameModeToComp()
    {
        TopLevelGameStateManager.instance.gameMode = TopLevelGameStateManager.GameMode.comp;
    }

    public void SetGameModeToNone()
    {
        TopLevelGameStateManager.instance.gameMode = TopLevelGameStateManager.GameMode.none;
    }
}

