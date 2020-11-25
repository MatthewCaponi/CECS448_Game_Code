using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel {
    
    private int playerID;
    public string Username { get; set; }
    public string Password { get; set; }

    // constructor
    public PlayerModel(int playerID, string username, string password){
        this.SetPlayerID(playerID);
        this.Username = username;
        this.Password = password;
    }
    private int GetPlayerID()
    {
        return playerID;
    }

    private void SetPlayerID(int value)
    {
        playerID = value;
    }
}
