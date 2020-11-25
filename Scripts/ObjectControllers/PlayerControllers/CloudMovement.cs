using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudMovement : MonoBehaviour
{
    [SerializeField] KeyCode moveCloudUp;
    [SerializeField] KeyCode moveCloudDown;
    [SerializeField] float cloudSpeed;

    [SerializeField] Transform topLane;
    [SerializeField] Transform bottomLane;
    private Vector3 centerLane;

    private bool canMoveUp = true;
    private bool canMoveDown = true;
    // Start is called before the first frame update
    void Start()
    {
        centerLane = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstLane()
    {
        transform.position = new Vector3(transform.position.x, -3, transform.position.z);
    }
    public void SecondLane()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    public void ThirdLane()
    {
        transform.position = new Vector3(transform.position.x, 3, transform.position.z);
    }
}
