using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    [SerializeField] Sprite[] transitionScreens;
    private int screenIndex;

    private SpriteRenderer spriteRenderer;


    [SerializeField] String[] scenes;
    private int sceneIndex;

    Coroutine nextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nextScene = StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextScene()
    {
        screenIndex = GameData.GDMiniGameNumber;
        spriteRenderer.sprite = transitionScreens[screenIndex];
        
        yield return new WaitForSeconds(3f);
        
        sceneIndex = GameData.GDMiniGameNumber;
        SceneManager.LoadScene(scenes[sceneIndex]);
        
        StopCoroutine(NextScene());
    }


}
