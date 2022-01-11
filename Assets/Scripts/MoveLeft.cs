using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {

        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            //transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

        /*if(transform.position.x < xLim && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }
}
