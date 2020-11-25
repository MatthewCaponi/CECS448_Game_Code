using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterManager : MonoBehaviour
{

    
    public  string currentCharacter;

    public static GameCharacterManager instance = null;

    public string CurrentCharacter { get => currentCharacter; set => currentCharacter = value; }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
       
    }

}
