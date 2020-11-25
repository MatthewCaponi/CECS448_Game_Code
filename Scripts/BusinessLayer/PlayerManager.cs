using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;
    private PlayerModel playerModel = null;
    public int playerID;
    public string username;
    public string password;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void CreatePlayer()
    {
        playerModel = new PlayerModel(playerID, username, password);
    }

    private void DestroyPlayer()
    {
        if (playerModel != null)
        {
            playerModel = null;
        }
    }  

    private void getActivePlayer()
    {
        // not really sure
    }
}
