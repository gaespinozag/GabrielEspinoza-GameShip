using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomHealthSpawn : MonoBehaviour
{
    public Transform[] spawnLocation;
    public GameObject[] healthbuffPrefab;
    public float timetospawn;
    public float countdown;


    void Start()
    {
        countdown = timetospawn;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        {
            if (countdown <= 0)
            {
                countdown = timetospawn;
                int randHealth = Random.Range(0, healthbuffPrefab.Length);
                int randSpawnLocation = Random.Range(0, spawnLocation.Length);

                Instantiate(healthbuffPrefab[randHealth], spawnLocation[randSpawnLocation].position, transform.rotation);
            }



        }
    }
}
