using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour

{
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f, 0 );
    public float speed;
    public float forcejump = 2;
    public float speedRun;

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
        if(Input.GetKeyDown(KeyCode.Space)) 
        myRigidbody.velocity = Vector2.up * forcejump;
    }

    
}