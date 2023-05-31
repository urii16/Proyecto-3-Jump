using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    private Rigidbody playerRb;

    private float jumpForce = 6;
    public bool isOnTheGround = true;
    private bool _gameOver = false;

    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;

    public ParticleSystem walk_dirt;

    private Animator _anim;

    public bool GameOver { get => _gameOver; }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !_gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            _anim.SetTrigger("Jump_trig");
            walk_dirt.Stop();
            _audioSource.PlayOneShot(jumpSound);
        }

        if (_gameOver)
        {
            walk_dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnTheGround = true;
            walk_dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            _anim.SetBool(DEATH_B, true);
            _anim.SetInteger(DEATH_TYPE_INT, 2);
            _audioSource.PlayOneShot(crashSound);
            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame() 
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
