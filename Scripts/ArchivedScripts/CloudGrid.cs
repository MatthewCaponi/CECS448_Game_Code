using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CloudGrid : MonoBehaviour
{
    [SerializeField] [Range(.1f, 20f)] float yGridSize = .5f;

    private bool free = true;

    public bool Free { get => free; set => free = value; }
    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            if (free)
            {
                Vector2 snapPos;

                //if (transform.localPosition.y >= startingPos.y + 3)
                //{
                //    snapPos.y = startingPos.y + 3;
                //}
                //else
                //{
                    snapPos.y = Mathf.RoundToInt(transform.position.y / yGridSize) * yGridSize;
                //}
                

                transform.position = new Vector2(transform.position.x, snapPos.y);
            }
        }
    }
}
