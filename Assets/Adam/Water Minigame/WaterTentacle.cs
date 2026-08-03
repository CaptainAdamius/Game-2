using UnityEngine;

public class WaterTentacle : MonoBehaviour
{

    [SerializeField] WaterMinigame manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(manager.cupPos, -1.5f);
    }
}
