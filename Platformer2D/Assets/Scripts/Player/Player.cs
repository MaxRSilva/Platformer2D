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

    [Header("Animation Setup")]

    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float DownScaleX = -0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;


    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.RightShift))

            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;
        
        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed,myRigidbody.velocity.y);
        
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
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
          myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            Handlescalejump();
                   
        
        }
    }

    private void Handlescalejump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);

       

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
       myRigidbody.transform.DOScaleX(DownScaleX, animationDuration).SetLoops(1, LoopType.Yoyo).SetEase(ease);
        
    }*/
    
    

}

    