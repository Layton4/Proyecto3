using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrouOutOfBounds : MonoBehaviour
{
    private float XRange = -4.5f;
    void Update()
    {
        if (gameObject.transform.position.x < XRange)
        {
            Destroy(gameObject);
        }
    }
}
