using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 450f;
    public float gravityModifier = 0.9f;
    private bool isOnTheGround = true;
    public bool gameOver;


    void Start()
    {
        gameOver = false;
        Physics.gravity *= gravityModifier;
        playerRigidbody = GetComponent<Rigidbody>();
        //playerRigidbody.AddForce(Vector3.up * jumpForce);
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("suelo"))
        {
            isOnTheGround = true;
        }

        if (otherCollider.gameObject.CompareTag("Obstáculo"))
        {
            Debug.Log("GAMEOVER");
            //Time.timeScale = 0;
            gameOver = true;

        }

    }
}
