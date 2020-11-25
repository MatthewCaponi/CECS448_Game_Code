using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Register
{
    public int playerID { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public Register(int playerID, string email, string name, string username, string password)
    {
        this.playerID = playerID;
        this.email = email;
        this.name = name;
        this.username = username;
        this.password = password;
    }
    
}
