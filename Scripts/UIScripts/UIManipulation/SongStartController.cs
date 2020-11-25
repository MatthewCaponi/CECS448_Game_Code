using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongStartController : MonoBehaviour
{

    [SerializeField] AudioSource src;
    [SerializeField] Transform startPos;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldPOS = transform.TransformPoint(transform.position);


        if(startPos.position.x >= worldPOS.x && !started)
        {
            if (!src.isPlaying)
            {
                started = true;
                src.Play();
            }
        }



    }
}
