using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed=2.0f,_jumpHeight=15.0f,_gravity=1.0f,_yVelocity;
    private Vector3 move, velocity;
    private Animator _playerAnimator;
    private bool grabLedge,_ladderclimb;
    private LedgeCheck _ledge;
    private Transform _ladderexit;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (grabLedge == false && _ladderclimb==false)
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space)) 
            {
                _playerAnimator.SetBool("IsRolling", true);
            }
            else
            {
                _playerAnimator.SetBool("IsRolling", false);
                PlayerMovement();
            }
        }
            
        
        if(Input.GetKeyDown(KeyCode.E)&&grabLedge==true)
        {
            _playerAnimator.SetBool("IsClimbing", true);
            
        }
    }

    public void EnableMovementAfterRoll()
    {
        _playerAnimator.SetBool("IsRolling", false);
        
    }

    public void EnableMovement()
    {
        transform.position = _ledge.ClimbedPos();
        grabLedge = false;
        _controller.enabled = true;
    }

    public void LadderClimb(Transform exitPos)
    {
        _playerAnimator.SetBool("IsClimbingLadder", true);
        _ladderclimb = true;
        _ladderexit = exitPos;
        Debug.Log("Inside climb");
    }

    public void LadderClimbExit()
    {

        transform.position = _ladderexit.position;
        _playerAnimator.SetBool("IsClimbingLadder", false);
        _ladderclimb = false;
        Debug.Log("Inside exit");
    }

    void PlayerMovement()
    {
        if (_controller.isGrounded == true)
        {
            _playerAnimator.SetBool("IsJumping", false);
            float horizontalInput = Input.GetAxis("Horizontal");
            move = new Vector3(0, 0, horizontalInput);
            velocity = move * _speed;
            if (horizontalInput != 0)
            {
                Vector3 flip = transform.localEulerAngles;
                flip.y = move.z > 0 ? 0 : 180;
                transform.localEulerAngles = flip;
            }

            _playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            _playerAnimator.SetBool("IsJumping", true);
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void PlayLedgeGrabAnimation(Vector3 newPos,LedgeCheck ledge)
    {
        grabLedge = true;
        _controller.enabled = false;
        _playerAnimator.SetBool("GrabLedge", true);
        _playerAnimator.SetBool("IsJumping", false);
        _playerAnimator.SetFloat("Speed", 0.0f);
        transform.position = newPos;
        _ledge = ledge;
    }

}
