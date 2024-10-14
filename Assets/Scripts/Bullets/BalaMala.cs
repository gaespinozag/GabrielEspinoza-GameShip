using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMala : MonoBehaviour
{

    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * -5.0f * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }



}
