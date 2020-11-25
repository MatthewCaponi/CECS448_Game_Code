using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public RhythmAudioManager audioManager;
    public float FillSpeed = 1.0f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMax(audioManager.GetAudioSource().clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < slider.maxValue)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void SetMax(float newMax)
    {
        slider.maxValue = (slider.value + newMax)/100;
    }

}
