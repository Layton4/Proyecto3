using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrouOutOfBounds : MonoBehaviour
{
    private float XRange = -5f;

    void Update()
    {
        if (gameObject.transform.position.x < XRange)
        {
            Destroy(gameObject);
            Debug.Log($"+1 point");
        }
        
    }

    
}
