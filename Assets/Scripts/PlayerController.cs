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
    public ParticleSystem explotionParticleSystem;
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    private float speed = 10f;
    private float HorizontalInput;
    public ParticleSystem fastParticles;
    private float VerticalInput;

    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    private int vidas = 3;


    void Start()
    {
        gameOver = false;
        Physics.gravity *= gravityModifier;
        playerRigidbody = GetComponent<Rigidbody>();
        //playerRigidbody.AddForce(Vector3.up * jumpForce);
        playerAnimator = GetComponent<Animator>();
        deadtype = Random.Range(1, 3);
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        vidas = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            fastParticles.Stop();
            //SFX de salto
            playerAudioSource.PlayOneShot(jumpClip, 1f);
        }

        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * HorizontalInput);

        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * VerticalInput);

    }

    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("suelo"))
        {
            isOnTheGround = true;
            fastParticles.Play();
        }

        if (otherCollider.gameObject.CompareTag("Obstáculo"))
        {
            vidas--;
            Destroy(otherCollider.gameObject);
            ParticleSystem explotionPs = Instantiate(explotionParticleSystem, transform.position + offset, explotionParticleSystem.transform.rotation);
            explotionPs.Play();
            if (vidas<=0)
            {
                Gameover();
            }
            else
            {
                playerAnimator.SetTrigger("Crash Trig");
            }
        }

    }

    public void Gameover()
    {
        Debug.Log("GAMEOVER");
        //Time.timeScale = 0;
        gameOver = true;
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", deadtype);

        //Particulas al morir
        ParticleSystem explotionPs = Instantiate(explotionParticleSystem, transform.position + offset, explotionParticleSystem.transform.rotation);
        explotionPs.Play();
        fastParticles.Stop();

        //SFX muerte
        cameraAudioSource.volume = 0.05f;
        playerAudioSource.PlayOneShot(crashClip, 1f);

    }
}
