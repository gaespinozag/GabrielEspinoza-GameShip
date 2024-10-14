using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.SceneTemplate;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI TimerText;
    float elapsedTime;


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  
     }

}
