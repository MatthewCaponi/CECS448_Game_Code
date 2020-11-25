using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerEndGame : MonoBehaviour
{
    private bool spawned;
    [SerializeField] Character player;
    [SerializeField] TextMeshProUGUI victory;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spawned && collision.gameObject.layer == 17)
        {
            spawned = true;
            PlayerStateController.instance.state = PlayerStateController.PlayerState.victory;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponentInChildren<Collider2D>().enabled = false;
            Invoke("VictoryText", 1f);
        }
    }

    private void VictoryText()
    {
        victory.gameObject.SetActive(true);
        Invoke("VictoryState", .5f);
        

    }

    private void VictoryState()
    {
        player.Animator.SetBool("Victory", true);
        
    }

  
}
