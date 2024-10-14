using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] MalaShipPrefab;
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
            if (spawncountdown <= 0)
            {
                spawncountdown = timetospawn;
                int randEnemy = Random.Range(0, MalaShipPrefab.Length);
                int randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(MalaShipPrefab[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.Euler(180, 0, 0));
            }

        }



    }
}
