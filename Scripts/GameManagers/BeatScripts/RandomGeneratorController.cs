using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomGeneratorController : MonoBehaviour
{
    public static RandomGeneratorController instance = null;

    private System.Random nextMovementType;
    private System.Random nextMovementType2;
    private Random nextMonster;
    private Random nextMonster2;
    private Random randomRandoms;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextMovementType = new Random();
        nextMonster = new Random();

        nextMovementType2 = new Random();
        nextMonster2 = new Random();

        randomRandoms = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int NextRandomMovementType(int start, int end)
    {

        if (randomRandoms.Next(2) == 0)
        {
            return nextMovementType.Next(start, end);
        }
        else
        {
            return nextMovementType2.Next(start, end);
        }
        
    }

    public int NextRandomMonster(int start, int end)
    {
        if (randomRandoms.Next(0, 2) == 0)
        {
            return nextMonster.Next(start, end);
        }
        else
        {
            return nextMonster2.Next(start, end);
        }
    }
}
