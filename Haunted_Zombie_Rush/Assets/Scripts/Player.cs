using UnityEngine.Assertions;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float jumpForce = 100f;

    [SerializeField]
    private AudioClip sfxJump;

    [SerializeField]
    private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private bool jump = false;
    #endregion

    #region UnityFunctions
    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ibstacle")
        {
            rigidBody.AddForce(new Vector2( -50, 20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }
    #endregion


} // Player class
