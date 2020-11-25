using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(GameMusicManager.instance);
    }
    private void Update()
    {
        if (GameMusicManager.instance != null)
        {
            Destroy(GameMusicManager.instance);
        }
    }

}
