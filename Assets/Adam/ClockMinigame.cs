using TMPro;
using UnityEngine;

public class ClockMinigame : MonoBehaviour
{
    public float mgSpeed;

    public float startTime;
    float timer;

    float startPos;
    float tentaclePos;

    public float tentacleSpeed;

    public int goalPos, goalRange;

    string direction;
    enum mgState
        {
            ACTIVE, FINISH, RESULTS
        }
        mgState state;

    // For animation

    public Animator animator;
    public AnimationClip clockAnimation;

    // For debugging
    [SerializeField] TextMeshProUGUI tentacleText;
    [SerializeField] TextMeshProUGUI goalText;
    [SerializeField] TextMeshProUGUI timerText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = startTime / mgSpeed;
        startPos = Random.Range(-5f, 5f);
        tentaclePos = startPos;
        direction = "Left";
        state = mgState.ACTIVE;
        goalText.SetText("Goal position: " + goalPos);

        float speedMultiplier = clockAnimation.length / timer;
        animator.speed = speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case mgState.ACTIVE: PlayMinigame(); break;
            case mgState.FINISH: state = mgState.RESULTS;  break;
            default: break;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = mgState.FINISH;
        }
        if (timer <= 0)
        {
            state = mgState.RESULTS;
        }
    }

    public void PlayMinigame()
    {
        switch (direction)
        {
            case "Right": tentaclePos += tentacleSpeed * mgSpeed * Time.deltaTime; break;
            case "Left": tentaclePos -= tentacleSpeed * mgSpeed * Time.deltaTime; break;
            default: break;
        }
        timer -= Time.deltaTime;

        if (tentaclePos >= 5)
        {
            direction = "Left";
        }
        else if (tentaclePos <= -5)
        {
            direction = "Right";
        }

        tentacleText.SetText("Tentacle Pos: " + tentaclePos.ToString("F2"));
        timerText.SetText("Time: " + timer.ToString("F2"));
    }
    public bool PlayerWin()
    {
        if (tentaclePos >= (goalPos - goalRange / 2) && tentaclePos <= (goalPos + goalRange / 2))
        {
            Debug.Log("Success!");
            return true;
        } else
        {
            Debug.Log("Failed.");
            return false;
        }
    }
}
