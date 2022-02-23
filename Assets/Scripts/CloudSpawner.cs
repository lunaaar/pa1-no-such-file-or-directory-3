using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] clouds;

    public float maxSpawnTime;
    public float currentSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null || GameObject.FindGameObjectWithTag("Player").activeSelf==false) {
            return;
        }

        if(currentSpawnTime <= 0f){
            currentSpawnTime = maxSpawnTime;

            GameObject cloud = clouds[Random.Range(0, clouds.Length)];

            float random = Random.Range(0f, 4f);
            Instantiate(cloud, new Vector3(-7f, random, 0f), Quaternion.identity);

        } else {
            currentSpawnTime -= Time.deltaTime;
        }
    }
}
