using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PlayerSong : IComparable<PlayerSong>
{
    public int PlayerID { get; set; }
    public int SongID { get; set; }
    public string Username { get; set; }
    public int Score { get; set; }
   
   

    public PlayerSong(int playerID, int songID, string username, int score)
    {
        this.PlayerID = playerID;
        this.SongID = songID;
        this.Username = username;
        this.Score = score;
    }

    // sorting algorithm 
    public int CompareTo(PlayerSong other)
    {
        // first > second return -1 
        // first < second return 1 
        // first == second return 0
        if (other.Score < this.Score)
        {
            return -1;
        }
        else if (other.Score > this.Score)
        {
            return 1;
        }
        return 0;
    }
}
