using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private void Start()
    {
        
    }


    private void Update()
    {
        Movement();


    }

    public float speed = 2f;
    

    void Movement()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 1.5f), -1, 0) * speed * Time.deltaTime);
    }


    public PowerUpsEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))

            {
                Destroy(this.gameObject);
                powerupEffect.Apply(collision.gameObject);
            }
        }
    }

}

