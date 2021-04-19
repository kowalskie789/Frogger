using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Spawner : MonoBehaviour
{
    public GameObject Game_Controller;
    public GameObject[] Logs;
    public Transform Spawn_Point_1;
    public Transform Spawn_Point_2;
    public Transform Spawn_Point_3;

    private float SpawnDelay;

    private float LogDelaySurplus;

    private float NextSpawnTime = 0f;
    private float NextSpawnTime_2 = 0f;
    private float NextSpawnTime_3 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay = Game_Controller.GetComponent<Variables>().log_spawn_delay;
        LogDelaySurplus = Game_Controller.GetComponent<Variables>().log_spawn_delay_random;
    }

    // Update is called once per frame
    void Update()
    {

        if (NextSpawnTime <= Time.time)
        {
            int randomIndex = Random.Range(0, Logs.Length);
            Instantiate(Logs[randomIndex], Spawn_Point_1);
            
                NextSpawnTime = SpawnDelay + Random.Range(0,LogDelaySurplus) + Time.time;
            
        }

        if (NextSpawnTime_2 <= Time.time)
        {
            int randomIndex_2 = Random.Range(0, Logs.Length);
            Instantiate(Logs[randomIndex_2], Spawn_Point_2);
            NextSpawnTime_2 = SpawnDelay + Random.Range(0, LogDelaySurplus) + Time.time;
        }

        if (NextSpawnTime_3 <= Time.time)
        {
            int randomIndex_3 = Random.Range(0, Logs.Length);
            Instantiate(Logs[randomIndex_3], Spawn_Point_3);
            NextSpawnTime_3 = SpawnDelay + Random.Range(0, LogDelaySurplus) + Time.time;
        }
    }
}
