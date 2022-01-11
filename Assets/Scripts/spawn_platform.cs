using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawn_platform : MonoBehaviour
{
    public GameObject platform;
    private Vector3 spawnPosition;
    private int lowlim = 2;
    private int y;


    void Start()
    {
       
        InvokeRepeating("spawnplat", 5, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnplat()
    {
        y = Random.Range(lowlim, 14);
        spawnPosition = new Vector3(48, y, 0);
        Instantiate(platform, spawnPosition, platform.transform.rotation);
    }
    
}
