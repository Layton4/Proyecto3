using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRoll : MonoBehaviour
{
    private float speed = 10f;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
