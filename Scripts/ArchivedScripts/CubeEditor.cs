using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(.1f, 20f)] float xGridSize = 1f;
    [SerializeField] [Range(.1f, 20f)] float yGridSize = .5f;
    private Vector2 tileLocation;
    private bool filled = false;

    public Vector3 TileLocation { get => tileLocation; }
    public bool Filled { get => filled; set => filled = value; }

    void Start()
    {
        tileLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / xGridSize) * xGridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / yGridSize) * yGridSize;
                          
        transform.position = new Vector2(snapPos.x, snapPos.y);
        tileLocation = transform.position;          
        
    }
}
