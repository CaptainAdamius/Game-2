using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WonkyHandController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float maxVelocity = 5f;

    [Header("Drift Settings (The Wonkiness)")]
    public float driftStrength = 2f;
    public float driftSpeed = 3f;

    private Rigidbody2D rb;

    private bool tentacleTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow movement input if we aren't currently slamming down
        if (Input.GetKeyDown(KeyCode.Space)&& tentacleTouching)
        {
            HitButton();
        }
    }

    void FixedUpdate()
    {

        // 1. Get WASD Input
        float moveX = Input.GetAxisRaw("Horizontal"); // A, D
        float moveY = Input.GetAxisRaw("Vertical");   // W, S
        Vector2 inputVector = new Vector2(moveX, moveY).normalized;

        // 2. Generate Random Floating Drift using Perlin Noise
        float noiseX = Mathf.PerlinNoise(Time.time * driftSpeed, 0f) * 2f - 1f;
        float noiseY = Mathf.PerlinNoise(0f, Time.time * driftSpeed) * 2f - 1f;
        Vector2 driftVector = new Vector2(noiseX, noiseY) * driftStrength;

        // 3. Apply Forces to Rigidbody
        Vector2 totalForce = (inputVector * moveSpeed) + driftVector;
        rb.AddForce(totalForce);

        // 4. Cap Maximum Speed so it doesn't fly off-screen entirely
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("button"))
        {
            Debug.Log("over button");
            tentacleTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("button"))
        {
            tentacleTouching = false;
            Debug.Log("Not touching");
        }
    }
    private void HitButton()
    {
        SceneManager.LoadScene("Handshake");
    }
}

