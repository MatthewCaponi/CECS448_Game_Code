using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSwitchController : MonoBehaviour
{
    [SerializeField] GameObject rankingsSwitch;
    [SerializeField] GameObject songInfoSwitch;
    public void SwitchToRankings()
    {
        rankingsSwitch.SetActive(true);
        songInfoSwitch.SetActive(false);
    }

    public void SwitchToSongInfo()
    {
        rankingsSwitch.SetActive(false);
        songInfoSwitch.SetActive(true);
    }
}
