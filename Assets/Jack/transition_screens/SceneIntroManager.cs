using UnityEngine;
using UnityEngine.Events;

public class SceneIntroManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private GameObject introScreenUI;
    [SerializeField] private GameObject backgroundPanel; // NEW: Drag your transparent background sprite/panel here

    [Header("Countdown Durations")]
    [SerializeField] private float movementUnlockTime = 3f; // Time until player can move (3 seconds)
    [SerializeField] private float totalIntroDuration = 4f;  // Total time until "GO!" finishes (4 seconds)

    [Header("Events")]
    public UnityEvent onCountdownFinished;

    public static bool IsIntroActive { get; private set; } = true;

    void Awake()
    {
        IsIntroActive = true;
    }

    void Start()
    {
        if (introScreenUI != null) introScreenUI.SetActive(true);
        if (backgroundPanel != null) backgroundPanel.SetActive(true);

        // Timer 1: Unlocks movement and hides the dark background panel at 3 seconds
        Invoke(nameof(UnlockGameplay), movementUnlockTime);

        // Timer 2: Fully shuts off the remaining "GO!" text overlay at 4 seconds
        Invoke(nameof(FinishCountdown), totalIntroDuration);
    }

    private void UnlockGameplay()
    {
        IsIntroActive = false; // Player can now move and drift!

        // NEW: Turn off just the background tint so the user can clearly see the level
        if (backgroundPanel != null)
        {
            backgroundPanel.SetActive(false);
        }
    }

    private void FinishCountdown()
    {
        // Turn off the rest of the text overlay entirely once "GO!" is finished
        if (introScreenUI != null)
        {
            introScreenUI.SetActive(false);
        }

        onCountdownFinished?.Invoke();
    }
}

