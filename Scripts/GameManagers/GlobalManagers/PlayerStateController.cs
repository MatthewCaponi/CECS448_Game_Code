using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public enum PlayerState { alive, dead, victory };
    public PlayerState state;
    [SerializeField] Character player;
    public static PlayerStateController instance = null;
    public bool turnedOff = false;



    public int MaxHP;
    public int currentHP;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        MaxHP = 100;
        currentHP = MaxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStateController.instance.turnedOff == false)
        {
            if (currentHP <= 0)
            {
                instance.state = PlayerStateController.PlayerState.dead;
                Debug.Log(state.ToString());
                player.Animator.SetBool("DieBack", true);
            }
        }
        
    }

    public void ChangePlayerState(PlayerState state)
    {
        this.state = state;
    }

    public void subtractHP(int dmg)
    {
        if (currentHP > 0)
        {
            if (currentHP - dmg < 0)
            {
                currentHP = 0;
            }
            else
            {
                currentHP = currentHP - dmg;
            }

        }
    }

    public void addHP(int heal)
    {
        if (currentHP < 100)
        {
            if (currentHP + heal > 100)
            {
                currentHP = 100;
            }
            else
            {
                currentHP = currentHP + heal;
            }
            
        }
        
    }
}
