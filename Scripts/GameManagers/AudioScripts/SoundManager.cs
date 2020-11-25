using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] whooshEffects;
    [SerializeField] AudioClip[] hitEffects;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip barrier;

    public static SoundManager instance = null;

    public AudioClip[] WhooshEffects { get => whooshEffects; set => whooshEffects = value; }
    public AudioClip[] HitEffects { get => hitEffects; set => hitEffects = value; }
    public AudioSource Audio { get => audio; set => audio = value; }
    public AudioClip Barrier1 { get => barrier; set => barrier = value; }

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this; 
    }
}
