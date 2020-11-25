using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{

    public Image LoadingBar;
    public Image LoadingBar2;
    public Image LoadingBar3;
    public Image LoadingBar4;
    float fillPercent;
    public float speed;
    public float offset = 1f;
    public float offset2 = 1f;
    public float offset3 = 1f;
    public float offset4 = 1f;

    private float beatTiming;
    private float fps;
    private float totalFrames;
    private float beatOffset;
    private float secOffset;
    private float secPercent;

    private float currentTime;

    //public RhythmGameManager RGM;

    // Start is called before the first frame update
    void Start()
    {
        beatTiming = BeatManager.instance.SongPositionBeats;

        //if (SongAnalyzer.instance.songState == SongState.slow)
        //{
        //    beatOffset = 200;
        //}
        //else if (SongAnalyzer.instance.songState == SongState.buildUp)
        //{
        //    beatOffset = 250;
        //}

        beatOffset = .25f * BeatTimingController.instance.BeatFactor;
        secOffset = BeatManager.instance.SecPerBeat * beatOffset;
        fillPercent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        beatOffset = .25f * BeatTimingController.instance.BeatFactor;
        secOffset = BeatManager.instance.SecPerBeat * beatOffset;

        currentTime += Time.deltaTime;
        

       
        if (fillPercent < 1)
        {
            fillPercent = currentTime / secOffset;/*Time.deltaTime * (totalFrames * Time.deltaTime);*/
            LoadingBar.fillAmount = fillPercent;
            //Debug.Log("currentTime:" + currentTime);
            //Debug.Log("secOffset: " + secOffset);
            //Debug.Log("secPercent: " + secPercent);
            //Debug.Log("fillPercent:" + fillPercent);
        }



        //LoadingBar2.fillAmount = (currentValue * offset2) / 100;
        //LoadingBar3.fillAmount = (currentValue * offset3) / 100;
        //LoadingBar4.fillAmount = (currentValue * offset4) / 100;

        if (LoadingBar.fillAmount == 1 && LoadingBar2.fillAmount == 1 && LoadingBar3.fillAmount == 1 && LoadingBar4.fillAmount == 1)
        {
            
            Invoke("DestroyEnemy", secOffset); 
        }

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public float GetFillPercent()
    {
        return fillPercent;
    }
}
