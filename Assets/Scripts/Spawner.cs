using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;

    public float timeBetweenSpawns; //initial time between spawns (start value)
    public float minSpawnTime; //fastest that we can spawn enemies
    public float decreaseAmt; //hgoiw fast we reach the min spawn time

    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnTime = 1f; //we will spawn on the first frame (the timer is 0)
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            //pick random enemy prefab
            GameObject go = enemies[Random.Range(0, enemies.Length)];
            float xPos = Random.Range(-9f, 9f);
            float yPos = 6f;
            float zPos = 0f;
            Instantiate(go, new Vector3(xPos, yPos, zPos), Quaternion.identity);

            //increasing difficulty after every spawn
            timeBetweenSpawns -= decreaseAmt;
            if(timeBetweenSpawns < minSpawnTime)
            {
                timeBetweenSpawns = minSpawnTime;
            }

            spawnTime = timeBetweenSpawns;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
    public void Reset()
    {
        timeBetweenSpawns = 2f;
    }
}
