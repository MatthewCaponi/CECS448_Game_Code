using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NoteSnap : MonoBehaviour
{

    [SerializeField] int gridPos = 10;

    // Update is called once per frame




    void Update()
    {
        if (!Application.isPlaying)
        {
            Vector2 snapPos;
            snapPos.x = Mathf.RoundToInt(transform.position.x / gridPos) * gridPos;
            snapPos.y = Mathf.RoundToInt(transform.position.y / gridPos) * gridPos;

            transform.position = new Vector2(snapPos.x, snapPos.y);
        }
        


    }
}
