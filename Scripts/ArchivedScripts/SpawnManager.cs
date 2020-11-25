using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] float instantiateRate;
    [SerializeField] GameObject beatManager;
    [SerializeField] int numMonsters;
    private GameObject enemy;
    private Vector3 instantiatePos = new Vector2(0,0);
    bool started = false;
    bool startDelay = false;
    [SerializeField] GameObject[] monsterSpawnLocations;
    [SerializeField] GameObject[] monsters;
    [SerializeField] int walkingSpawn;
    public bool finished = false;

    public static SpawnManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //monsterSpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");

        //monsters = new GameObject[numMonsters];
        //for (int i = 0; i < monsters.Length; ++i)
        //{
        //    monsters[i] = Resources.Load
        //}
    }

  

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            if (!finished)
            {
                if (!started)
                {
                    started = true;
                    StartCoroutine(SpawnTimer());
                }
            }
            else if (!started)
            {
                started = true;

            }
        }
        
        
        
    }

    IEnumerator SpawnTimer()
    {
        if (startDelay == false)
        {
            startDelay = true;
            yield return new WaitForSeconds(BeatManager.instance.SongStartOffset - (BeatManager.instance.SecPerBeat));
        }

        while (true)
        {
            SpawnEnemy();


            yield return new WaitForSeconds(BeatTimingController.instance.SpawnFactor * BeatManager.instance.SecPerBeat);
        }
        
    }

    private void SpawnEnemy()
    {
        var randLocation = RandomLocation();
        var randMonster = RandomMonster(numMonsters);

        if (monsters[randMonster].GetComponent<EnemyMovementController>().MovementType1 == EnemyMovementController.MovementType.Walk)
        {
            enemy = Instantiate(monsters[randMonster], monsterSpawnLocations[walkingSpawn].transform, false);
            enemy.transform.position = monsterSpawnLocations[walkingSpawn].transform.position;
        }
        else
        {
            enemy = Instantiate(monsters[randMonster], monsterSpawnLocations[randLocation].transform, false);
            enemy.transform.position = monsterSpawnLocations[randLocation].transform.position;
        }
        


    }

    private void SpawnEnemy(GameObject giantSpawn)
    {
            enemy = Instantiate(giantSpawn, monsterSpawnLocations[0].transform, false);
            enemy.transform.position = monsterSpawnLocations[0].transform.position;

    }

    private int RandomMonster(int numMonsters)
    {
        System.Random random = new System.Random();
        int randLocation = random.Next(1, numMonsters + 1);

        return randLocation - 1;
    }

    private int RandomLocation()
    {
        System.Random random = new System.Random();
        int randLocation = random.Next(1, 5);

        return randLocation - 1;

    }
}
