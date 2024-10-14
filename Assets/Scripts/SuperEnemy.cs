using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();



    }

    public float speed = 2f;
    public int health = 5;
    private GameObject enemyshipPrefab;
    public float zigzagApmlitude = 5f;
    public float zigzagFrequency = 5f;
    public GameObject bulletPref;
    public Transform bulletPosition;
    private float timer;

    void Movement()
    {

        float zigzagMovement = Mathf.Sin(Time.time * zigzagFrequency) * zigzagApmlitude;



        transform.Translate(new Vector3(zigzagMovement, 1, 0) * speed * Time.deltaTime);

    }
    void Shooting()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }

        void shoot()
        {
            var bullet3 = Instantiate(bulletPref, transform.position + new Vector3(0f, 0f, 0f), Quaternion.Euler(180, 0, 0));
            var bullet1 = Instantiate(bulletPref, transform.position + new Vector3(-0.5f, 1f, 1f), Quaternion.Euler(180, 0, 0));
            var bullet2 = Instantiate(bulletPref, transform.position + new Vector3(0.5f, 1f, 1f), Quaternion.Euler(180, 0, 0));
        }

        
    }


    }

