using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnList : MonoBehaviour
{
    [SerializeField] Transform lowSpawn;
    [SerializeField] Transform medSpawn;
    [SerializeField] Transform highSpawn;

    public Transform LowSpawn { get => lowSpawn; set => lowSpawn = value; }
    public Transform MedSpawn { get => medSpawn; set => medSpawn = value; }
    public Transform HighSpawn { get => highSpawn; set => highSpawn = value; }


    // Start is called before the first frame update
}
