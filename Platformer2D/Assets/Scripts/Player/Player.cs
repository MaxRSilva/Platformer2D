using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour

{
    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;
    
    // public Animator animator;
    
    

    private float _currentSpeed;
    private bool _isRunning = false;

    [Header("Setup")]

    public SOPlayerSetup soPlayerSetup;

    private Animator _currentPlayer;

    [Header("Jump Collision Check")]

    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    
        if(collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }    
    
    }
    
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }
    
    
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }


    private void Update()
    {
        IsGrounded();
        HandleJump();
        HandleMoviment();
    }
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.SetBool(soPlayerSetup.boolSpeed, true);
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.SetBool(soPlayerSetup.boolSpeed, false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed,myRigidbody.velocity.y);
            //myRigidbody.transform.localScale = new Vector3(-1, 1 ,1);
            //animator.SetBool(boolRun, true);
            
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);


        }
        else if(Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            //myRigidbody.transform.localScale = new Vector3 (1, 1, 1);
            //animator.SetBool(boolRun, true);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else 
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);

        }


        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;   
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
          myRigidbody.velocity = Vector2.up * soPlayerSetup.forcejump;
          //myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            Handlescalejump();
            //_currentPlayer.SetBool(soPlayerSetup.boolJump, true);
            PlayJumpVFX();
        }
        
        else
        {
            //_currentPlayer.SetBool(soPlayerSetup.boolJump, false);

        }
    }

    private void PlayJumpVFX()
    {
        if(jumpVFX != null) jumpVFX.Play();
    }

    private void Handlescalejump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.JumpScaleY, soPlayerSetup.AnimationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.JumpScaleX, soPlayerSetup.AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);

       

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
       myRigidbody.transform.DOScaleX(DownScaleX, animationDuration).SetLoops(1, LoopType.Yoyo).SetEase(ease);
        
    }*/
    
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}

    