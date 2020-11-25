using Assets.Scripts.Data_Access;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoginDataGateway : MonoBehaviour
{
    private Repository repo;

    public PlayerLoginDataGateway()
    {
        repo = new Repository();
    }

    private void DropTable()
    {
        repo.DropTable("Player");
    }

    private void CreateTable()
    {
        string sqlQuery = "CREATE TABLE if not exists Player (PlayerID INTEGER, Email TEXT UNIQUE, Name TEXT, Username TEXT UNIQUE, Password TEXT, PRIMARY KEY(PlayerID AUTOINCREMENT))";
        repo.CreateTable(sqlQuery);
    }

    // Selection into the Player table "For an account"
    private void SelectAccount(string username, string password)
    {
        // logic completed for (playerID, username, password) Just incase it is needed just add (int playerID) to be the first parameter 
        // .................................................................................................................................
        //string sqlQuery = "SELECT PlayerID, Username, Password FROM Player WHERE playerid = '" + playerID + "' username = '" + username + "' AND password = '" + password +"'";
        
        string sqlQuery = "SELECT Username, Password FROM Player WHERE username = '" + username + "' AND password = '" + password +"'";
        repo.Select(sqlQuery);
    }
}
