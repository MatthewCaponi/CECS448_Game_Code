using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

using Assets.Scripts.Data_Access;

public class PlayerSongDataGateway
{
    private string dbName;
    private List<PlayerSong> playerSongs = new List<PlayerSong>();
    private List<List<PlayerSong>> highScoreTables = new List<List<PlayerSong>>();
  
    public int topRanks;
    public int saveScores;
    private Repository repo;

    // Start is called before the first frame update
    
    public PlayerSongDataGateway()
    {
        repo = new Repository();
    }
        
    private void DropTable()
    {
        repo.DropTable("PlayerSong");
       
    }

    private void CreateTable()
    {
        string sqlQuery = "CREATE TABLE if not exists PlayerSong (PlayerId INTEGER, SongId INTEGER, Username TEXT, Score INTEGER, PRIMARY KEY(PlayerId), FOREIGN KEY(SongId) REFERENCES Song(Id), FOREIGN KEY(PlayerId) REFERENCES Player(Id));";
        repo.CreateTable(sqlQuery);
    }

    // Insertion into the PlayerSong table "For the Score"
    public void InsertScore(int playerId, int songId, string username, int score)
    {
        {
            string query = string.Format("INSERT INTO PlayerSong(PlayerId, SongId, Username, Score) VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\");", playerId, songId, username, score);
            repo.Insert(query);
        }
    }

    private void GetOneScore()
    {
        IDataReader reader = repo.GetRowById("PlayerSong", "PlayerId", 2);

        reader.Read();
        Debug.Log(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString());

        reader.Close();
    }

    public List<PlayerSong> GetAllScores()
    {
        playerSongs.Clear();

        IDataReader reader = repo.GetAllData("PlayerSong");   
        
        while (reader.Read())
        {
            playerSongs.Add(new PlayerSong(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));             
        }

        reader.Close();
        playerSongs.Sort();

        return playerSongs;
    }

    private void deleteScore(string tableName, int playerId)
    {
        
        repo.DeleteById(tableName, playerId);
    }

    public List<PlayerSong> GetAllScoresBySongId(int songId)
    {
        List<PlayerSong> playerSongs = new List<PlayerSong>();

        IDataReader reader = repo.FilterResultsById("PlayerSong", "SongId", songId);

        while (reader.Read())
        {
            playerSongs.Add(new PlayerSong(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));
        }

        reader.Close();
        playerSongs.Sort();

        return playerSongs;
    }

    

    // Delete extra scores (If we only want 10 scores, and we have 20 scores it will erase the lowest 10 scores)
    private void DeleteExtraScores()
    {
       // getScore();

        if (saveScores <= playerSongs.Count)
        {
            int deleteCounter = playerSongs.Count - saveScores;
            playerSongs.Reverse();

            // Create the db connection
            using (IDbConnection connection = new SqliteConnection(dbName))
            {
                connection.Open();

                // set up an object (called "command") to allow db control 
                using (IDbCommand command = connection.CreateCommand())
                {
                    for (int i = 0; i < deleteCounter; i++)
                    {
                        string sqlQuery = string.Format("DELETE FROM PlayerSong WHERE PlayerID = \"{0}\"", playerSongs[i].PlayerID);
                        command.CommandText = sqlQuery;
                        command.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
        }
    }
}
