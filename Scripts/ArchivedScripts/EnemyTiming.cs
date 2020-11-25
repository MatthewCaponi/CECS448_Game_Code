using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTiming : MonoBehaviour
{
    private float beatTiming;
    private float fps;
    private float totalFrames;
    private float beatOffset;
    private float secOffset;
    private float secPercent;
    private float currentTime;
    private float percentReached;
    private float distanceToPlayer;
    private bool moving;
    private EnemyMovementController enemyMovementController;
    // Start is called before the first frame update
    void Start()
    {
        beatOffset = .25f * BeatTimingController.instance.BeatFactor;
        secOffset = BeatManager.instance.SecPerBeat * beatOffset;
        distanceToPlayer = gameObject.transform.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;
        enemyMovementController = GetComponent<EnemyMovementController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            if (enemyMovementController.moving)
            {
                beatOffset = BeatTimingController.instance.BeatFactor;
                secOffset = BeatManager.instance.SecPerBeat * beatOffset;

                currentTime += Time.deltaTime;

                if (percentReached < 1)
                {
                    percentReached = currentTime / secOffset;/*Time.deltaTime * (totalFrames * Time.deltaTime);*/
                    gameObject.transform.position -= new Vector3(distanceToPlayer * (percentReached), 0, 0);
                    //Debug.Log("currentTime:" + currentTime);
                    //Debug.Log("secOffset: " + secOffset);
                    //Debug.Log("secPercent: " + secPercent);
                    //Debug.Log("fillPercent:" + fillPercent);
                }
            }
        }
        
        
    }
}
