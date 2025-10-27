using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerMovement : MonoBehaviour
{
    public bool IsCrouching { get; private set; }

    public Sprite[] playerSprites = new Sprite[4];
    private SpriteRenderer currentSprite;
    private Transform tr;
    public float speed = 11f;

    //jump
    public float jumpForce = 5f;
    public LayerMask groundMask;
    public float groundCheckDistance = 1f;

    private Rigidbody rb;
    private bool isGrounded;

    private Animator anim;

    public AudioSource gingerbread; 

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(xAxis, 0f, zAxis);

        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);


        //tr.Translate(move * speed * Time.deltaTime, Space.World);
        ChangeSprite();

        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     Debug.Log("button is pressed");
        //     speed *= 2;
        // } 
        // else
        // {
        //     speed = 50;
        // }

        //jump -----

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        IsCrouching = Input.GetKey(KeyCode.LeftControl);

    }

    public void ChangeSprite()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow))
        {

            anim.SetBool("backWalk", true);
            gingerbread.Play();
            WalkShake();
        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("backWalk", false);
            currentSprite.sprite = playerSprites[0];
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            anim.SetBool("leftWalk", true);
            gingerbread.Play();
            WalkShake();
        }
        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("leftWalk", false);
            currentSprite.sprite = playerSprites[1];
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow))
        {

            anim.SetBool("frontWalk", true);
            gingerbread.Play();
            WalkShake();
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("frontWalk", false);
            currentSprite.sprite = playerSprites[2];
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {

            anim.SetBool("rightWalk", true);
            gingerbread.Play();
            WalkShake();
        }
        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("rightWalk", false);
            currentSprite.sprite = playerSprites[3];
        }
    }

    public void WalkShake()
    {
        CameraShaker.Instance.ShakeOnce(1f, 2f, .1f, 1f);
    }
}
