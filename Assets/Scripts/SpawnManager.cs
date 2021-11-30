using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefabs;
    public Vector3 spawnPosition = new Vector3(30, 0, -1);
    private float XRange = -1f;


    void Start()
    {
        InvokeRepeating("spawnObstacle", 4, 3);
    }

    void Update()
    {
        
    }

    public void spawnObstacle()
    {
        Vector3 altura = new Vector3(0, gameObject.transform.localScale.y / 2f, 0);
        Instantiate(ObstaclePrefabs, spawnPosition + altura, ObstaclePrefabs.transform.rotation);
    }
}
