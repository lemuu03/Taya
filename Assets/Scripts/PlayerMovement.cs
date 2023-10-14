using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    [Header ("PlayerMovement")]
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    [Header ("Player Shoot")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] AudioClip playerJump;
    Vector2 moveInput; // for x and y char movement
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;

    [Header ("PowerUp")]
    [SerializeField] bool hasPowerUp;
    [SerializeField] float powerUpTimer = 10f;
    bool hasKey;
    bool isRight;
    bool isLeft;
    bool isUp;
    bool isInvulnerable;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>(); 
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive){ return;}
        Run();
        FlipSprite();
        ClimbLadder();

        if(hasPowerUp)
        {
            powerUpTimer -= Time.deltaTime;
        
            if (powerUpTimer < 0)
            {
                powerUp(false);
                powerUpTimer = 10f;
            }
        }

        // if(isInvulnerable)
        // {
        //     cdTimer -= Time.deltaTime;
        //     isInvulnerable = false;
        // }

        //MOBILE INPUTS

        if(isRight)
        {
            transform.Translate(Vector2.right * 1 * playerSpeed * Time.deltaTime);
            transform.localScale = new Vector2(1f, 1f);
            CreateDust();
            myAnimator.SetBool("isRunning", true); //change bool from false to true

        }
        
        if(isLeft)
        {
            transform.Translate(Vector2.right * -1 * playerSpeed * Time.deltaTime);
            transform.localScale = new Vector2(-1f, 1f);
            CreateDust();
            myAnimator.SetBool("isRunning", true); //change bool from false to true
        }

        if(isUp)
        {
            if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                myRigidbody.gravityScale = gravityScaleAtStart;
                myAnimator.SetBool("isClimbing", false); // so if the player is not touching the ladder it will not be animated
                return;
            }
            transform.Translate(Vector2.up * 1 * playerSpeed * Time.deltaTime);
            myAnimator.SetBool("isClimbing", true);

        }
        
    }
    

    void OnFire(InputValue value)
    {
        if (!isAlive){ return; }
        if(value.isPressed && hasPowerUp)
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }

    public void powerUp(bool powerUp)
    {
        hasPowerUp = powerUp;        
    }   

    public void HoldKey(bool key)
    {
        hasKey = key;
    }

    void OnMove(InputValue value)
    {
        if (!isAlive){ return;}
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive){ return;}

        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Climbing")))
        {
            if(value.isPressed)
            {
                myRigidbody.velocity += new Vector2(0f, jumpSpeed);
                SoundFXManager.instance.PlaySoundFXClip(playerJump, transform, 1f); // PLAY SOUNDFX
            }
        }
        CreateDust();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed); //change bool from false to true
    }

    void FlipSprite()
    {
        CreateDust();
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    

    void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false); // so if the player is not touching the ladder it will not be animated
            return;
        }

        // adding velocity for the player to move vertically
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        // myRigidbody.gravityScale = 0f;

        // To determine if the player is climbing
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed); // if the player has vertical speed then it will animate the climbing animation
    }

    //MOBILE INPUTS

    public void rightButton()
    {
        isRight = true;
        isLeft = false;
        isUp = false;
    }
    public void leftButton()
    {
        isLeft = true;
        isRight = false;
        isUp = false;
    }

    public void upButton()
    {
        isLeft = false;
        isRight = false;
        isUp = true;
    }

    public void fireButton()
    {
        if (!isAlive){ return; }
       
        if(hasPowerUp)
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }

    public void jumpButton()
    {
        if (!isAlive){ return;}

        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Climbing")))
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            SoundFXManager.instance.PlaySoundFXClip(playerJump, transform, 1f); // PLAY SOUNDFX
        }
    }
    
    void CreateDust()
    {
        dust.Play();
    } 
}
