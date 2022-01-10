using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefabs;
    public Vector3 spawnPosition = new Vector3(30, 0, -0.2f);
    private float startDeLay = 2f;
    private float repeatRate = 2f;
    private PlayerController playerControllerScript;

    void Start()
    {
        //altenative way playerControllerScript = FindObjectOfType<PlayerController>(); 
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //el primero que aparezca si hay más de uno que se llama a ti
        InvokeRepeating("spawnObstacle", startDeLay, repeatRate);
    }

    void Update()
    {
        
    }

    public void spawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        { 
        //Vector3 altura = new Vector3(0, gameObject.transform.localScale.y / 2f, 0);
        Instantiate(ObstaclePrefabs, ObstaclePrefabs.transform.position, ObstaclePrefabs.transform.rotation);
        }
    }
}
