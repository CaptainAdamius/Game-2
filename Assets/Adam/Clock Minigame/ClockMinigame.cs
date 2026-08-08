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
        startPos = Random.Range(-5f, -1f);
        if (startPos > -3) { startPos += 6; }
        tentaclePos = startPos;
        direction = "Left";
        state = mgState.ACTIVE;
        goalText.SetText("Goal position: " + goalPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneIntroManager.IsIntroActive) return;
        PlayMinigame();
    }

    public void PlayMinigame()
    {


        if (tentacleMoving)
        {
            if (tentacleHeight < 1.5)
            {
                tentacleHeight += 8f * Time.deltaTime;
            }
            else
            {
                tentacleHeight = 1.5f;
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
            else
            {
                PlayerWin();
                tentacleMoving = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tentacleHeight >= 1.5f)
            {
                tentacleMoving = false;
            }
        }

    }
    public void PlayerWin()
    {
        if (!hasPlayerWon)
        {
            if (tentaclePos >= (goalPos - goalRange / 2) && tentaclePos <= (goalPos + goalRange / 2))
            {
                Debug.Log("Success!");
                GameData.GDTaskComplete = true;
                GameData.GDMiniGameNumber++;
                hasPlayerWon = true;
            }
            else
            {
                Debug.Log("Failed.");
            }
        }
        
    }
}
