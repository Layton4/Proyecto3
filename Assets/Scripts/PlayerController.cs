using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 450f;
    public float gravityModifier = 0.9f;


    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
