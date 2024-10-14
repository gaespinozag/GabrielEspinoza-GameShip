using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    public GameObject Lives1, Lives2, Lives3, gameOver;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        Lives1.gameObject.SetActive(true);
        Lives2.gameObject.SetActive(true);
        Lives3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
            health = 3;
        switch (health)
        {
            case 3:
                Lives1.gameObject.SetActive(true);
                Lives2.gameObject.SetActive(true);
                Lives3.gameObject.SetActive(true);
                break;
            case 2:
                Lives1.gameObject.SetActive(true);
                Lives2.gameObject.SetActive(true);
                Lives3.gameObject.SetActive(false);
                break;
            case 1:
                Lives1.gameObject.SetActive(true);
                Lives2.gameObject.SetActive(false);
                Lives3.gameObject.SetActive(false);
                break;
            case 0:
                Lives1.gameObject.SetActive(false);
                Lives2.gameObject.SetActive(false);
                Lives3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                break;
        }
    }
}
