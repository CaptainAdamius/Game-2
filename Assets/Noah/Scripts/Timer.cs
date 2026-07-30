using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] float maxTime;
    float currentTime;

    [SerializeField] Slider timerSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = maxTime;
        timerSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCode();
        TimerVisuals();
    }

    private void TimerCode()
    {
        if (currentTime <= 0)
        {
            Debug.Log("player loses");
            
            //Call gameManager script
            //Player loses heart
            //Check if player is out off hearts
            //Load next scene
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }

    private void TimerVisuals()
    {
        timerSlider.value = currentTime;
    }


    // float for maxTime -- [SerializeField] so it can be accessed in the editor
    // float currentTime 

    //if currentTime is not equal or greater than maxTime
    //Increase time - multiply by ime.detatime 
    //else
    // player loses if time runs out
    //go to next scene 
    //player loses life

    //Visuals 
    //Reference to ui slider on canvas
    // set slider maxValue to MaxTime
    //update 
    //Slider value equals currentTime float 
}
