using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
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

    public virtual void Movement()
    {
        transform.Translate(Vector3.up * 5.0f * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.Instance.AddPoint();

        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Destroy the enemy
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }

}
