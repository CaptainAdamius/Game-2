using TMPro;
using UnityEngine;

public class ClockMinigame : MonoBehaviour
{
    float tentaclePos;
    public float tentacleSpeed;
    public int goalPos, goalRange;
    string direction;
    [SerializeField] TextMeshProUGUI tentacleText;
    [SerializeField] TextMeshProUGUI goalText;
    string MinigameCurrentState;
    enum minigameState
    {
        ACTIVE, FINISH, RESULTS
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        tentaclePos = 0;
        direction = "Right";
        MinigameCurrentState = minigameState.ACTIVE.ToString();
        goalText.SetText("Goal position: " + goalPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MinigameCurrentState = minigameState.FINISH.ToString();
        }
        switch (MinigameCurrentState)
        {
            case "ACTIVE": PlayClockMinigame(); break;
            case "FINISH": CheckFinish(); MinigameCurrentState = minigameState.RESULTS.ToString();  break;
            default: break;
        }
    }

    public void PlayClockMinigame()
    {
        switch (direction)
        {
            case "Right": tentaclePos += tentacleSpeed; break;
            case "Left": tentaclePos -= tentacleSpeed; break;
            default: break;
        }

        if (tentaclePos >= 10)
        {
            direction = "Left";
        }
        else if (tentaclePos <= 0)
        {
            direction = "Right";
        }

        tentacleText.SetText("Tentacle Pos: " + tentaclePos.ToString("F2"));
    }
    public void CheckFinish()
    {
        if (tentaclePos >= (goalPos - goalRange / 2) && tentaclePos <= (goalPos + goalRange / 2))
        {
            Debug.Log("Success!");
        } else
        {
            Debug.Log("Failed.");
        }
    }
}
