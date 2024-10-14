using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variables
    public float speed = 5.5f;
    public float fireRate = 0.25f;
    public int lives = 4;
    public int shields = 3;
    public float canFire = 2f; //Time to fire again
    public float shieldDuration = 5.0f;
    public GameObject BulletPref;
    private bool shielded;
    public GameObject Shield;
    public GameObject ShipsPref;
    private SpriteRenderer spriteRenderer;
    //To use audio
    public AudioManager audioManager;
    public AudioSource actualAudio;
    public int maxHealth = 4;
    public int currentHealth;




    private void Start()
    {
        Shield.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        lives = maxHealth;
        Debug.Log("Lives: " +  lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBoundaries();
        ChangeWeapon();
        CheckShields();
        Fire();
        ChangeShipAppearence();
        
    }



    //Character Movement, use WASD keys to move the player
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

    }

    void CheckShields()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
           Shield.SetActive(true);
            shielded = true;
            //code for turning off shield
            Invoke("NoShield", 10f);
        }
    }

    void NoShield()
    {
        Shield.SetActive(false);
        shielded = false;
    }




    void CheckBoundaries()
    {
        //Check for boundaries of the game, use Main Camera to set the boundaries
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        float yMax = cam.orthographicSize;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y, 0);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, -yMax, 0);
        }
        else if (transform.position.y < -yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, 0);
        }
    }

    //Player Fire
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            //Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            //canFire = Time.time + fireRate;

            //Play the sound of the bullet
            //actualAudio = audioManager.GetAudio("Bullet");
            //actualAudio.Play();

            switch (BulletPref.name)
            {
                case "Bullet1":
                    Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    actualAudio.pitch = Random.Range(0.8f, 1f);
                    actualAudio.Play();
                    break;

                case "Bullet3":
                    var bullet1 = Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    bullet1.GetComponent<Misiliazo>().direction = Vector2.up;

                    var bullet2 = Instantiate(BulletPref, transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
                    bullet2.GetComponent<Misiliazo>().direction = new Vector2(0.5f, 1);

                    var bullet3 = Instantiate(BulletPref, transform.position + new Vector3(-0.5f, 0.8f, 0), Quaternion.identity);
                    bullet3.GetComponent<Misiliazo>().direction = new Vector2(-0.5f, 1);

                    canFire = Time.time + fireRate + 1f;
                    actualAudio.pitch = Random.Range(0.4f, 0.7F);
                    actualAudio.Play();
                    break;

                case "Bullet2":
                    var bullet4 = Instantiate(BulletPref, transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
                    bullet4.GetComponent<Bola>().direction = new Vector3(5f, 0, 0);

                    var bullet5 = Instantiate(BulletPref, transform.position + new Vector3(-0.5f, 0.8f, 0), Quaternion.identity);
                    bullet4.GetComponent<Bola>().direction = new Vector3(-5f, 0, 0);

                    canFire = Time.time + fireRate + 1f;
                    actualAudio.pitch = Random.Range(1.5f, 2f);
                    actualAudio.Play();
                    break;

                case "Bullet4":
                    var bullet6 = Instantiate(BulletPref, transform.position + new Vector3(-0.5f, 1f, 1f), Quaternion.identity);
                    bullet6.GetComponent<Elipse>().direction = new Vector2(0f, 0);

                    var bullet7 = Instantiate(BulletPref, transform.position + new Vector3(0.5f, 1f, 1f), Quaternion.identity);
                    bullet7.GetComponent<Elipse>().direction = new Vector2(0f, 0);

                    var bullet8 = Instantiate(BulletPref, transform.position + new Vector3(1f, 0f, 1f), Quaternion.identity);
                    bullet8.GetComponent<Elipse>().direction = new Vector2(0f, 0);

                    var bullet9 = Instantiate(BulletPref, transform.position + new Vector3(-1f, 0f, 1f), Quaternion.identity);
                    bullet9.GetComponent<Elipse>().direction = new Vector2(0f, 0);

                    canFire = Time.time + fireRate + 1f;
                    actualAudio.pitch = Random.Range(1f, 1.3f);
                    actualAudio.Play();
                  
                    break;
            }
        }
    }
    //public GameObject BulletPref; ----> esta es la bala que se va a disparar

    public List<Bullet> bullets;
    

    public void ChangeWeapon()
    {
        //For changing weapons, use the number keys 1, 2, 3, 4

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletPref = bullets[0].gameObject;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletPref = bullets[1].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPref = bullets[2].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            BulletPref = bullets[3].gameObject;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Destroy the enemy
                Destroy(collision.gameObject);
                if (lives > 1)
                {
                    if (!shielded)
                    {
                        lives--;
                        Debug.Log("Lives: " + lives);
                        ChangeShipAppearence();
                    }
                }
                else
                {
                    lives--;
                    //Destroy the player
                    Destroy(this.gameObject);

                    Debug.Log("Player Died");

                    SceneManager.LoadScene("Game Over");
                }
               
            }
        }
    }
    public List<Sprite> ships;
    void ChangeShipAppearence()
    {
        if (lives > 0 && lives <= ships.Count)
        {
            spriteRenderer.sprite = ships[lives - 1];
        }

        else
        {
            Debug.LogWarning("Lives out of bounds or not enough sprites assigend.");
        }

    }

    public void Heal(int healAmount)
    {
        lives += healAmount;
        if (lives > maxHealth)
        {
            lives = maxHealth;
        }
    }



    
}
