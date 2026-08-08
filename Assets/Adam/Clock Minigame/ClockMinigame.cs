using TMPro;
using UnityEngine;

public class ClockMinigame : MonoBehaviour
{
    public float mgSpeed;

    float startPos;
    public float tentaclePos;
    public float tentacleHeight;
    public float tentacleRange;
    public float tentacleSpeed;
    public float goalPos, goalRange;
    bool tentacleMoving;
    bool hasPlayerWon;
    string direction;
    enum mgState
        {
            ACTIVE, FINISH, RESULTS
        }
        mgState state;

    // For debugging
    [SerializeField] TextMeshProUGUI tentacleText;
    [SerializeField] TextMeshProUGUI goalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tentacleMoving = true;
        tentacleHeight = 1.5f;
        hasPlayerWon = false;
        startPos = Random.Range(-tentacleRange, tentacleRange);
        tentaclePos = startPos;
        direction = "Left";
        state = mgState.ACTIVE;
        goalText.SetText("Goal position: " + goalPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneIntroManager.IsIntroActive) return;
        

        switch (state)
        {
            case mgState.ACTIVE: PlayMinigame(); break;
            case mgState.FINISH: PlayerWin(); state = mgState.RESULTS;  break;
            default: break;
        }
        
    }

    public void PlayMinigame()
    {


        if (tentacleMoving)
        {
            if (tentacleHeight <= 1.5)
            {
                tentacleHeight += 8f * Time.deltaTime;
            }
            else
            {
                switch (direction)
                {
                    case "Right": tentaclePos += tentacleSpeed * mgSpeed * Time.deltaTime; break;
                    case "Left": tentaclePos -= tentacleSpeed * mgSpeed * Time.deltaTime; break;
                    default: break;
                }
                if (tentaclePos >= tentacleRange)
                {
                    direction = "Left";
                }
                else if (tentaclePos <= -tentacleRange)
                {
                    direction = "Right";
                }
            }

            tentacleText.SetText("Tentacle Pos: " + tentaclePos.ToString("F2"));

        } else if (!tentacleMoving)
        {
            if (tentacleHeight >= -1.2)
            {
                tentacleHeight -= 8f * Time.deltaTime;
            }
            else if (tentacleHeight <= -1.2)
            {
                PlayerWin();
                tentacleMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tentacleMoving = false;
        }

    }
    public void PlayerWin()
    {
        if (tentaclePos >= (goalPos - goalRange / 2) && tentaclePos <= (goalPos + goalRange / 2))
        {
            Debug.Log("Success!");
            hasPlayerWon = true;
            GameData.GDTaskComplete = true;
            GameData.GDMiniGameNumber++;
        } else
        {
            Debug.Log("Failed.");
            hasPlayerWon = false;
        }
    }
}
