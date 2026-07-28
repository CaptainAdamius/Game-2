using UnityEngine;
using UnityEngine.Rendering.UI;

public class DrinkingMiniGame : MonoBehaviour
{
    float drinkNumber;
    [SerializeField]float drinkGoal = 5;

    Transform drinkRotation;
    [SerializeField] float rotationIncrease;
    float currentRotation;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinkRotation = transform; // set drinkRotation to the pivot gameObject (the game object with this script attached)
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //when spacebar is pressed
        {
            Drink(); //do drink function code
        }
        

    }

    private void Drink()
    {

        drinkNumber++; //coun ts how many times the player presses space
        Rotate(); // do rotate function code
        if (drinkNumber >= drinkGoal) // if the DrinkNumber is equal or greater than the drinGoal
        {
            //move to next scene  - this will connect with the universal game manager script
            Debug.Log("win"); 
        }
        
    }


    private void Rotate()
    {
        currentRotation += rotationIncrease; // increase the currentFotation float by the given rotationIncrease value
        drinkRotation.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentRotation);// rotates the arm and drink by the currentRotation value on the z axis 
    }

    
    
    
    //float drinkNumber 
    //float drinkGoal

    //when space is presses increase drink number by one 
    //if drink number equals or is greater than drinkgoal
    //player wins mini game

    //visuals 
    //transform Drinkrotation
    // float rotationIncrease
    //float currentRotaiton

    //everytime drinknumber increases 
    // increase currentRotaion by rotaitonIncrease float value 
    //change DrinkRotation transform.localEulerAngles by currentRoation 



}
