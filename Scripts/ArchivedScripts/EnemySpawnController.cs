using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private Transform[] beats;
    // Start is called before the first frame update
    void Start()
    {
        beats =  GetComponentsInChildren<Transform>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
