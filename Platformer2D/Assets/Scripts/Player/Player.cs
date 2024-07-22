using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour

{
    public Rigidbody2D myRigidbody;
    
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0 );
    public float speed;
    public float forcejump = 2;
    public float speedRun;
    public HealthBase healthBase;

    [Header("Animation Setup")]

    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float DownScaleX = -0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public Animator animator;
    public float playerSwipeDuration;
    public string boolSpeed = "Speed";
    public string triggerDeath = "Death";
    public string boolJump = "Jump";


    private float _currentSpeed;
    private bool _isRunning = false;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }
    
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }


    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            _currentSpeed = speedRun;
            animator.SetBool(boolSpeed, true);
        }
        else
        {
            _currentSpeed = speed;
            animator.SetBool(boolSpeed, false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed,myRigidbody.velocity.y);
            //myRigidbody.transform.localScale = new Vector3(-1, 1 ,1);
            //animator.SetBool(boolRun, true);
            
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);


        }
        else if(Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            //myRigidbody.transform.localScale = new Vector3 (1, 1, 1);
            //animator.SetBool(boolRun, true);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else 
        {
            animator.SetBool(boolRun, false);

        }


        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;   
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          myRigidbody.velocity = Vector2.up * forcejump;
          //myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            Handlescalejump();
            animator.SetBool(boolJump, true);
        }
        
        else
        {
            animator.SetBool(boolJump, false);

        }
    }

    private void Handlescalejump()
    {
        //myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        //myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);

       

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

    