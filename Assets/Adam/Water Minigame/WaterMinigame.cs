using TMPro;
using UnityEngine;

public class WaterMinigame : MonoBehaviour
{

    public float mgSpeed;

    float startPos;
    public float cupPos;
    float cupSpeed;
    float cupFill;
    bool hasPlayerWon;
    int coolerPos = 0;
    public float coolerRange;
    public GameObject water;
    enum mgState
    {
        ACTIVE, FINISH, RESULTS
    }
    mgState state;

    // For debugging
    [SerializeField] TextMeshProUGUI fillText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        water.SetActive(false);
        hasPlayerWon = false;
        startPos = Random.Range(-5f, -1f);
        if (startPos > -3) {startPos += 6;}
        cupPos = startPos;
        state = mgState.ACTIVE;
        cupFill = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneIntroManager.IsIntroActive) return;

        switch (state)
        {
            case mgState.ACTIVE: PlayMinigame(); break;
            case mgState.FINISH: state = mgState.RESULTS; break;
            default: break;
        }

        if (cupFill >= 1)
        {
            PlayerWin();
        }
    }

    public void PlayMinigame()
    {
        if (Input.GetKey(KeyCode.A)) {
            cupSpeed -= 0.05f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            cupSpeed += 0.05f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && cupPos >= (coolerPos - coolerRange / 2) && cupPos <= (coolerPos + coolerRange / 2))
        {
            water.SetActive(true);
            cupFill += 0.3f * mgSpeed * Time.deltaTime;
        }
        else { water.SetActive(false);}

            cupPos += cupSpeed * mgSpeed; if (cupPos < -5 || cupPos > 5) {cupSpeed = 0;} cupPos = Mathf.Clamp(cupPos, -5, 5);

        fillText.SetText("Cup Fill: " + cupFill.ToString("F2"));
    }

    public void PlayerWin()
    {
        if (!hasPlayerWon)
        {
            GameData.GDTaskComplete = true;
            GameData.GDMiniGameNumber++;
            hasPlayerWon = true;
        }
    }
}
