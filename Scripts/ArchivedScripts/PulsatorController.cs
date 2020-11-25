using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsatorController : MonoBehaviour
{
    public Image LoadingBar;
    public Image LoadingBar2;
    public Image LoadingBar3;
    public bool pulse = false;
    public bool started = false;
    public Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = LoadingBar.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(Pulsator());
        }
    }

    public IEnumerator Pulsator()
    {
        while (true)
        {

            StartCoroutine(Pulsate());
            yield return new WaitForSeconds(BeatManager.instance.SecPerBeat);
        }
    }

    public IEnumerator Pulsate()
    {
        for (int i = 0; i < 2; ++i)
        {
            if (pulse)
            {
                LoadingBar.color = Color.white;
                pulse = false;
            }
            else if (!pulse)
            {
                LoadingBar.color = originalColor;
                pulse = true;
            }
        }

        yield return new WaitForEndOfFrame();
        
    }
}
