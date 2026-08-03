using UnityEngine;

public class ClockTentacle : MonoBehaviour
{
    [SerializeField] ClockMinigame manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(manager.tentaclePos, 2f);
    }
}
