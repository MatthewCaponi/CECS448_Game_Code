using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    private List<PlayerSong> playerSongs;
    private PlayerSongDataGateway dataGateway;
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int songId;
    // Start is called before the first frame update
    void Start()
    {
        playerSongs = new List<PlayerSong>();
        dataGateway = new PlayerSongDataGateway();

        ShowTableBySong(songId);
    }

    public void ShowTableBySong(int songId)
    {
        ShowScores(songId);
    }

    private void ShowScores(int songId)
    {
        List<PlayerSong> playerSongs = dataGateway.GetAllScoresBySongId(songId);

        for (int i = 0; i < playerSongs.Count; ++i)
        {

            if (i <= playerSongs.Count - 1)
            {
                // Instantiate the prefab for (score, rank, name)
                GameObject tmpObject = Instantiate(scorePrefab);
                // Copying score into list
                PlayerSong tmpScore = playerSongs[i];

                tmpObject.GetComponent<HighScoreViewItem>().SetScore(tmpScore.Username, tmpScore.Score.ToString(), "#" + (i + 1).ToString());
                tmpObject.transform.SetParent(scoreParent);

                // scale the rows 
                tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(tmpObject.GetComponent<RectTransform>().localPosition.x, tmpObject.GetComponent<RectTransform>().localPosition.y, 0);
                Debug.Log(tmpScore.Score.ToString());
            }
        }
    }
}
