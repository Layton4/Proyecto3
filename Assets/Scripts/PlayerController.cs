using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 450f;
    public float gravityModifier = 0.9f;
    private bool isOnTheGround = true;
    public bool gameOver;
    public Animator playerAnimator;

    private int deadtype;

    void Start()
    {
        gameOver = false;
        Physics.gravity *= gravityModifier;
        playerRigidbody = GetComponent<Rigidbody>();
        //playerRigidbody.AddForce(Vector3.up * jumpForce);
        playerAnimator = GetComponent<Animator>();
        deadtype = Random.Range(1, 3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig");
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
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", deadtype);
        }

    }
}
