using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefabs;
    public Vector3 spawnPosition = new Vector3(30, 0, -0.2f);
    private float startDeLay = 2f;
    private float repeatRate = 2f;
    void Start()
    {
        InvokeRepeating("spawnObstacle", startDeLay, repeatRate);
    }

    void Update()
    {
        
    }

    public void spawnObstacle()
    {
        //Vector3 altura = new Vector3(0, gameObject.transform.localScale.y / 2f, 0);
        Instantiate(ObstaclePrefabs, ObstaclePrefabs.transform.position, ObstaclePrefabs.transform.rotation);
    }
}
