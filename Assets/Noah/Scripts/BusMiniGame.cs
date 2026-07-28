using Unity.VisualScripting;
using UnityEngine;

public class BusMiniGame : MonoBehaviour
{


    public float rotation;
    [SerializeField] GameObject rotationPivot;
    [SerializeField] float pivotSpeed;
    [SerializeField] float rotationIncrease;
    [SerializeField] float gravScale;
    [SerializeField] float rotationClamp;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationGrav(); 
        RotateAlien();
        
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
        rotationPivot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotation);
    }

    private void RotateAlien()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            rotation += rotationIncrease * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rotation -= rotationIncrease * Time.deltaTime;
        }
        rotation = Mathf.Clamp(rotation, -rotationClamp, rotationClamp);
        rotationPivot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotation);// set the aimpivots rotation to the currentAngleRotation

    }

  

    //Get the rotation of the alien
    //get input action of the "Horizonal" axis  - old input system

    //if the player presses A or left arrow
    //rotate the player left on the z axis

    // if the player presses D or right arrow 
    //rotate the player right on the z axis

    // if the players z rotation is greater that max rotation 
    // and if the players z rotation is less than min rotation
    // player lose minigame
    // remove heart from player

    
    //timer 
    //Increase the timer 
    // is timer float is greater than max time 
    // player wins minigame
    // go to transition screen 


}
