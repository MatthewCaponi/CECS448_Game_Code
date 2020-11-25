using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreViewItem : MonoBehaviour
{
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;

    public void SetScore(string name, string score, string rank)
    {
        this.rank.GetComponent<TextMeshProUGUI>().text = rank;
        this.scoreName.GetComponent<TextMeshProUGUI>().text = name;
        this.score.GetComponent<TextMeshProUGUI>().text = score;
    }
}
