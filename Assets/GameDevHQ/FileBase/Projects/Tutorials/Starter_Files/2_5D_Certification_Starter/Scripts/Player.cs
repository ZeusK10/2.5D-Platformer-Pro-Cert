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

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_controller.isGrounded==true)
        {
            _playerAnimator.SetBool("IsJumping", false);
            float horizontalInput = Input.GetAxis("Horizontal");
            move = new Vector3(0, 0, horizontalInput);
            velocity = move * _speed;
            if(horizontalInput!=0)
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
}
