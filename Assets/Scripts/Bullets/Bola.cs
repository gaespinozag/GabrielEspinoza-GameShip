using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bola : Bullet
{

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    public override void Movement()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 1.5f), 1, 0) * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision != null)
        {
            Debug.Log("Collided with: " + collision.gameObject.name);

            if (collision.gameObject.CompareTag("Enemy"))
            {
                ScoreManager.Instance.AddPoint();
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
