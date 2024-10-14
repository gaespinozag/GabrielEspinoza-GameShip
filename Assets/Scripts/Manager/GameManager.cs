using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1.5f;
    public float time = 0.0f;
    public Player player;
    public TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI TimerText;
    float elapsedTime;
    public GameObject live1, live2, live3, live4;
    public static int lives;
    public GameObject bullet1, bullet2, bullet3, bullet4;

    private void Start()
    {
        lives = player.lives;
        bullet1.gameObject.SetActive(true);
        bullet2.gameObject.SetActive(false);
        bullet3.gameObject.SetActive(false);
        bullet4.gameObject.SetActive(false);


    }



    // Update is called once per frame
    void Update()
    {
        //CreateEnemy();
        UpdateCanvas();
        LiveCounter();
        WeaponShow();
    }

    

      void UpdateCanvas()
    {
        liveText.text = "Life: " + player.lives;
        
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void LiveCounter()
    {
        if (player.lives > 4)
            player.lives = 4;

        switch (player.lives)
        {
            case 4:
                live1.gameObject.SetActive (true);
                live2.gameObject.SetActive (true);
                live3.gameObject.SetActive (true);
                live4.gameObject.SetActive (true);
                break;

            case 3:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(true);
                Debug.Log(live1.activeSelf);
                live4.gameObject.SetActive(false);
                Debug.Log(live1.activeSelf);
                break;

            case 2:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(false);
                live4.gameObject.SetActive(false);
                break;
            case 1:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                live4.gameObject.SetActive(false);
                break;
            case 0:
                live1.gameObject.SetActive(false);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                live4.gameObject.SetActive(false);
                break;
        }

    }
    public void WeaponShow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bullet1.gameObject.SetActive(true);
            bullet2.gameObject.SetActive(false);
            bullet3.gameObject.SetActive(false);
            bullet4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bullet1.gameObject.SetActive(false);
            bullet2.gameObject.SetActive(true);
            bullet3.gameObject.SetActive(false);
            bullet4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bullet1.gameObject.SetActive(false);
            bullet2.gameObject.SetActive(false);
            bullet3.gameObject.SetActive(true);
            bullet4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bullet1.gameObject.SetActive(false);
            bullet2.gameObject.SetActive(false);
            bullet3.gameObject.SetActive(false);
            bullet4.gameObject.SetActive(true);
        }
    }



    /* private void CreateEnemy()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            time = 0.0f;
        }
    }*/


}
