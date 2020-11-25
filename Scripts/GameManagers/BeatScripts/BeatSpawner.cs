using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    private string spawnType;
    private GameObject monster;
    private bool spawned = false;
    private bool numSwitch;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
        if (!spawned && collision.gameObject.layer == 17)
        {
            Debug.Log("Start Point Triggered");

            spawned = true;

     
            int rand = RandomGeneratorController.instance.NextRandomMovementType(0, 4);

            Debug.Log("Movement Rand: " + rand);
            if (rand == 0)
            {
           
                Debug.Log("LOWER");
                Transform spawnLocation = collision.GetComponent<MonsterSpawnList>().LowSpawn;
                SpawnEnemy(EnemyMovementController.MovementType.Walk, spawnLocation, false);
            }
            else if (rand == 1)
            {
                Debug.Log("MIDDLE");
                Transform spawnLocation = collision.GetComponent<MonsterSpawnList>().MedSpawn;
                SpawnEnemy(EnemyMovementController.MovementType.Idle, spawnLocation, false);
            }
            else if (rand == 2)
            {
                Debug.Log("HIGHER");
                Transform spawnLocation = collision.GetComponent<MonsterSpawnList>().MedSpawn;
                SpawnEnemy(EnemyMovementController.MovementType.Idle, spawnLocation, false);
            }
            else if (rand == 3)
            {

                Debug.Log("LOWER");
                Transform spawnLocation = collision.GetComponent<MonsterSpawnList>().LowSpawn;
                SpawnEnemy(EnemyMovementController.MovementType.Walk, spawnLocation, true);
            }
        }
        
        
    }

    private GameObject ChooseMonster(EnemyMovementController.MovementType movementType, bool isObstacle)
    {
        int rand;
        if (isObstacle)
        {
            rand = RandomGeneratorController.instance.NextRandomMonster(1, 7);
        }
        else
        {
            rand = RandomGeneratorController.instance.NextRandomMonster(1, 6);
        }
        
        Debug.Log("Monster Rand: " + rand);
        string path = "Enemies/" + level + "/" + movementType.ToString() + "/" + rand.ToString();
        Debug.Log(path);
        GameObject tempEnemy = Resources.Load(path) as GameObject;

        return tempEnemy;
    }

    private void SpawnEnemy(EnemyMovementController.MovementType movementType, Transform spawnLocation, bool isObstacle)
    {
        GameObject tempEnemy = ChooseMonster(movementType, isObstacle);
        
        monster = Instantiate(tempEnemy);
        monster.transform.parent = transform;
        monster.transform.position = new Vector3(transform.position.x, spawnLocation.transform.position.y, -.5f);
        monster.transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
