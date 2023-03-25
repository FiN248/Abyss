using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Collider2D myCollider2D;
    public float speed = 1.0f;
    public Animator PlayAnim;
    [Header("Jump parameter")]
    public float playerJumpSpeed;
    public float playerJumpCount;
    public bool isGround;
    public bool isJump;
    public bool pressedJump;
    public LayerMask Ground;
    public Transform foot;


    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        PlayAnim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateCheck();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerJump();
        FixedUpdateCheck();
    }
    void PlayerMovement()
    {
        float horizontalMovement;     
        horizontalMovement = Input.GetAxis("Horizontal");       

        float horizontalFaceDirection = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement != 0)        
        {
            myRigidbody2D.velocity = new Vector2(horizontalMovement * speed, myRigidbody2D.velocity.y);     
        }

        PlayAnim.SetFloat("run", Mathf.Abs(horizontalMovement * speed));

        if (horizontalFaceDirection != 0)  
        {
            this.transform.localScale = new Vector3(horizontalFaceDirection, 1, 1);   
        }

    }

    void PlayerJump()
    {
        if (isGround)
        {
            playerJumpCount = 1;
            isJump = false;
        }
        if (pressedJump && isGround)
        {
            pressedJump = false;
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, playerJumpSpeed);
            PlayAnim.SetBool("jump", true);
            playerJumpCount--;
        }
        else if (pressedJump && playerJumpCount >0 && !isGround)
        {   
            PlayAnim.SetBool("jump", true);
            pressedJump = false;
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, playerJumpSpeed);
            playerJumpCount--;
        }
        if (isGround)
        {
            PlayAnim.SetBool("jump", false);
        }
        
    }

    void FixedUpdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground);
    }

    void UpdateCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
        
    }
}
