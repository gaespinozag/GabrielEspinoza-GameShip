using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] asteroidsPrefab;
    public float timetospawn;
    public float spawncountdown;

    // Start is called before the first frame update
    void Start()
    {
        spawncountdown = timetospawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawncountdown -= Time.deltaTime;
        {
            if(spawncountdown <= 0)
            {
                spawncountdown = timetospawn;
                int randEnemy = Random.Range(0, asteroidsPrefab.Length);
                int randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(asteroidsPrefab[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            }

        }



    }
}
