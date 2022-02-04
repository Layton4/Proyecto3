using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat_player : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    private Vector3 end = new Vector3(35, 0, 0);

    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        if (transform.position.x > end.x)
        {
            transform.position = startPosition;
        }
    }
}
