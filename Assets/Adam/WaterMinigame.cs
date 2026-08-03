using TMPro;
using UnityEngine;

public class WaterMinigame : MonoBehaviour
{

    public float mgSpeed;

    public float startTime;
    float timer;

    float startPos;
    float cupPos;
    float cupSpeed;
    float cupFill;

    int coolerPos = 0;
    public int coolerRange;

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
    [SerializeField] TextMeshProUGUI cupText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI fillText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = startTime / mgSpeed;
        startPos = Random.Range(-5f, -1f);
        if (startPos > -3) {startPos += 6;}
        cupPos = startPos;
        state = mgState.ACTIVE;
        cupFill = 0;

        float speedMultiplier = clockAnimation.length / timer;
        animator.speed = speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case mgState.ACTIVE: PlayMinigame(); break;
            case mgState.FINISH: state = mgState.RESULTS; break;
            default: break;
        }

        if (cupFill >= 1)
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
        if (Input.GetKey(KeyCode.A)) {
            cupSpeed -= 0.000002f;
        }
        if (Input.GetKey(KeyCode.D)) {
            cupSpeed += 0.000002f;
        }
        if (Input.GetKey(KeyCode.Space) && cupPos >= (coolerPos - coolerRange / 2) && cupPos <= (coolerPos + coolerRange / 2))
        {
            cupFill += 0.0003f * mgSpeed;
        }
        

        cupPos += cupSpeed * mgSpeed; if (cupPos < -5 || cupPos > 5) {cupSpeed = 0;} cupPos = Mathf.Clamp(cupPos, -5, 5);

        timer -= Time.deltaTime;

        cupText.SetText("Cup Pos: " + cupPos.ToString("F2"));
        timerText.SetText("Time: " + timer.ToString("F2"));
        speedText.SetText("Cup Speed: " + cupSpeed.ToString());
        fillText.SetText("Cup Fill: " + cupFill.ToString("F2"));
    }
}
