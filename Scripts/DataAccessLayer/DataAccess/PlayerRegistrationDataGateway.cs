using Assets.Scripts.Data_Access;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerRegistrationDataGateway : MonoBehaviour
{
    private Repository repo;

    public PlayerRegistrationDataGateway()
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

    // Insert Registration 
    public void register(int playerId, string email, string name, string username, string password)
    {
        string sqlQuery = string.Format("INSERT INTO Player(PlayerId, Email, Name, Username, Password) VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\");", playerId, email, name, username, password);
        repo.Insert(sqlQuery);
    }

    public void RegisterChecker(string username)
    {
        string sqlQuery = "SELECT UsernameFROM Player WHERE username = '" + username + "'";
        if (username != "") 
        {
            repo.Select(sqlQuery);
        }
        
    }
}
