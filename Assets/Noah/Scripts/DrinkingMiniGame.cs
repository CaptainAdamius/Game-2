using UnityEngine;
using UnityEngine.Rendering.UI;

public class DrinkingMiniGame : MonoBehaviour
{
    float drinkNumber;
    [SerializeField]float drinkGoal = 5;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && drinkNumber !>= drinkGoal)
        {
            drinkNumber++;
            Debug.Log("Drink");
        }
        else
        {
            Debug.Log("Win");
        }

       
    }
}
