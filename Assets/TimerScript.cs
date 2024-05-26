using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour
{
    private float timeRemaining = 90f;
    public bool timeIsRunning = true;
    public TMP_Text timeText;

    void Start()
    {
        timeIsRunning = true;
    }

    void Update()
    {
        if(timeIsRunning){
            if(timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                Displaytime(timeRemaining);
            }
            else{
                    timeRemaining = 0;
                    Time.timeScale = 0f;
                    timeIsRunning = false;
                   WinLosePage losePage = FindObjectOfType<WinLosePage>();
                    if (losePage != null)
                    {
                        losePage.ActivateLosePanel();
                    }
            }
        }
    }
    
    void Displaytime(float timeToDisplay){
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}