using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiliazo : Bullet
{
    public Vector2 direction;


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision != null)
        {
            Debug.Log("Collided with: " + collision.gameObject.name);

            if (collision.gameObject.CompareTag("Enemy"))
            {
                ScoreManager.Instance.AddPoint1();
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
