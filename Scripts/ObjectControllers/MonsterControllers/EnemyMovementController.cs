using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] float speed;
    public enum MovementType { Walk, Idle };
    [SerializeField] MovementType movementType;

    public bool moving = true;

    public MovementType MovementType1 { get => movementType; set => movementType = value; }

    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            if (moving && !(gameObject.GetComponent<SkeletonAnimation>().AnimationName == "Attack"))
            {
                gameObject.GetComponent<SkeletonAnimation>().AnimationName = MovementType1.ToString();
            }
        }

    }

    public void StopMovement()
    {
        moving = false;
    }
}
