using UnityEngine;
using UnityEngine.Rendering.UI;
using static UnityEditor.FilePathAttribute;

public class DrinkingMiniGame : MonoBehaviour
{
    float drinkNumber;
    [SerializeField]float drinkMax;
    bool middle;
    

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
       
        HalfWay();

        if (Input.GetKeyDown(KeyCode.W) && !middle && drinkNumber < drinkMax) //when W is pressed and not at middle and less than the drink max
        {
            Drink(); //do drink function code
        }
        else if (Input.GetKeyDown(KeyCode.A) && middle && drinkNumber < drinkMax) //when W is pressed and at middle and less than the drink max
        {
            Drink();//do drink function code
        }
        

    }

    private void Drink()
    {

        drinkNumber += rotationIncrease; //coun ts how many times the player presses space
        Rotate(); // do rotate function code
        if (drinkNumber >= drinkMax) // if the DrinkNumber is equal or greater than the drinGoal
        {
            //move to next scene - this will connect with the universal game manager script
            Debug.Log("win"); 
        }
        
    }


    private void Rotate()
    {
        currentRotation += rotationIncrease; // increase the currentFotation float by the given rotationIncrease value
        drinkRotation.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentRotation);// rotates the arm and drink by the currentRotation value on the z axis 
    }

    private void HalfWay()
    {
        if(currentRotation > drinkMax/2) // check if the drink has be rotated half way based of max drink
        {
            middle = true;// the player is halfway
        }
        else
        {
            middle= false;// the player isnot halfway
        }
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


        //randomise drink button
        //push one button to halfway - drinkTarget / 2
        //if drinkNumber is half of drinkTarget
        //switch to next button press 



    }
