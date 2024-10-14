using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;

    int score = 0;  
    int highscore = 0;

    private void Awake()
    {
        Instance = this;    
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Points: " + score.ToString();
        HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Points: " + score.ToString();
    }
    public void AddPoint1()
    {
        score += 2;
        scoreText.text = "Points: " + score.ToString();
    }
}
