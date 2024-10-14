using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elipse : Bullet
{

    public Vector2 direction;
    [SerializeField] Transform rotationCenter;
    [SerializeField] float angularSpeed = 2f;
    float posX, posY, angle = 0f;
    float forwardSpeed = 2f;
    float rotationRadiusX = 0.025f;
    float rotationRadiusY = 0.025f;
 


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {


        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadiusX / 2;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadiusY / 2;

        posY += Time.deltaTime * forwardSpeed;
        
        transform.position = new Vector2 (posX, posY);

        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0;
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


