using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class BusMiniGame2 : MonoBehaviour
{
    float rotation;
    [SerializeField] GameObject rotationPivot;
    [SerializeField] float pivotSpeed;
    [SerializeField] float rotationIncrease;

    [SerializeField] float gravScale;
    [SerializeField] float rotationClamp;

    private Coroutine knockEvent;
    [SerializeField] float betweenTime;


    [SerializeField] ScreenShake screenShake;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        knockEvent = StartCoroutine(KnockEvent());
    }
    private void Update()
    {
        rotationPivot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotation);
    }


    IEnumerator KnockEvent()
    { 
        yield return new WaitForSeconds(betweenTime);

        rotation = -90f;

        screenShake.StartScreenShake();
        while (rotation <0)
        {
            RotateAlienLeft();
            RotationGrav();
            yield return null;
        }

        rotation = 0;
       

        yield return new WaitForSeconds(betweenTime);

        rotation = 90f;

        screenShake.StartScreenShake();
        while (rotation > 0)
        {
            
            RotateAlienRight();
            RotationGrav();
            yield return null;
        }

        rotation = 0;
        

        StopCoroutine(KnockEvent());
    }
    
    
    private void RotationGrav()
    {
        if (rotation <= 0)
        {
            rotation -= gravScale;
        }
        else if (rotation is > 0)
        {
            rotation += gravScale;
        }
        rotation = Mathf.Clamp(rotation, -rotationClamp, rotationClamp);
    }

    private void RotateAlienLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotation += rotationIncrease;
            rotation = Mathf.Clamp(rotation, -rotationClamp, rotationClamp);
        }
    }

    private void RotateAlienRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotation -= rotationIncrease;
            rotation = Mathf.Clamp(rotation, -rotationClamp, rotationClamp);
        }
    }

    //Knock event 
    //corutine timeinbetween knock
    // bool DoneTask

    // on start begin corutine 
    //wait 3 seconds
    //Set players rotation z by 90
    //play knock animation

    //For as long as players rotaiton is not 0
    //add gravity 
    //player movement 

    //Wait 3 seconds 
    //set players rotation z by -90
    //play knock animation

    //For as long as players rotaiton is not 0
    //add gravity 
    //player movement 

    //doneTask = true;
    //end corutine

    //When timer is done, if doneTask equals true player wins else player loses


}
