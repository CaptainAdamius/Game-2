using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    [SerializeField] float duration = 1f;
    [SerializeField] AnimationCurve curve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartScreenShake()
    {
        StartCoroutine(Shaking());
    }

    public IEnumerator Shaking()
    {
        Vector3 startPoint = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) 
        {
           transform.position = startPoint;
            elapsedTime += Time.deltaTime;
            float strengh = curve.Evaluate(elapsedTime / duration);
            transform.position = startPoint + Random.insideUnitSphere * strengh;
            yield return null;
        }

        transform.position = startPoint;
    }
}
