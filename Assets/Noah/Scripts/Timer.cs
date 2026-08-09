using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] AnimationClip timerAnimtion;
    [SerializeField] float time;

    [SerializeField] SceneIntroManager sceneIntroManager;

    float timer;

    public enum timerSelection {TimeISWin, TimeIsLose}
    public timerSelection timerType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.GDTaskComplete = false;
    }

    private void Update()
    {

        if (SceneIntroManager.IsIntroActive) return;
        
        animator.Play("Cycle");

        
        
        



        UpdateTimer();

        switch (timerType)
        { 
            case timerSelection.TimeISWin:

                gameTimerWin();
                break;
            case timerSelection.TimeIsLose:
                gameTimerLose();
                break;
        }

    }

    private void gameTimerWin()
    {

        
        if (timer >= time)
        {
            if (GameData.GDTaskComplete)
            {
                GameData.GDMiniGameNumber++;
                SceneManager.LoadScene("Tranitions");
            }
            else
            {
                SceneManager.LoadScene("LoseScene");
            } 
        }
       
    }

    private void gameTimerLose()
    {

        
        if (GameData.GDTaskComplete)
        {
            //GameData.GDMiniGameNumber++;
            //SceneManager.LoadScene("Tranitions");
            sceneIntroManager.startWinGame();
        }
        else if (timer >= time)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void UpdateTimer()
    {
        timer += Time.deltaTime;
        float animationSpeed = timerAnimtion.length / time;
        animator.speed = animationSpeed;
    }

    //if (SceneIntroManager.IsIntroActive) return;
    //GameData.GDTaskComplete = true;
    //GameData.GDMiniGameNumber++;
    
}
