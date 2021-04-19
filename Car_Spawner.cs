using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject Game_Controller;
    public GameObject[] vehicles;
    public Transform Spawn_Point_1;
    public Transform Spawn_Point_2;
    private float SpawnDelay;           // minimum spawn delay
    private float TruckDelaySurplus;    // random time added to spawn delay 
    private float NextSpawnTime = 0f;
    private float NextSpawnTime_2 = 0f;

    private void Start()
    {
        SpawnDelay = Game_Controller.GetComponent<Variables>().Car_spawn_delay;
        TruckDelaySurplus = Game_Controller.GetComponent<Variables>().Car_spawn_delay_random;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSpawnTime <= Time.time)
        {
            int randomIndex = Random.Range(0, vehicles.Length);
            Instantiate(vehicles[randomIndex], Spawn_Point_1);
            NextSpawnTime = SpawnDelay + Random.Range(0, TruckDelaySurplus) + Time.time;
        }


        if (NextSpawnTime_2 <= Time.time)
        {
            int randomIndex_2 = Random.Range(0, vehicles.Length);
            Instantiate(vehicles[randomIndex_2], Spawn_Point_2);
            NextSpawnTime_2 = SpawnDelay + Random.Range(0, TruckDelaySurplus) + Time.time;
        }



    }
}
