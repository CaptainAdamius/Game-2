using System;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    Vector2 startPos;
    [SerializeField] float moveSpeed;
    float distance;
    [SerializeField] float Maxdistance;

    [SerializeField] float maxScale;
    [SerializeField] float minScale;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        randomScale();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (distance > Maxdistance)
        {
            distance = 0;
            transform.position = startPos;
            randomScale();


        }
        else
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            distance++;
        }


    }

    private void randomScale()
    {
        float randScale = UnityEngine.Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * randScale;

    }
}
