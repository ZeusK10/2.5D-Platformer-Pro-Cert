using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed=2.0f,_jumpHeight=15.0f,_gravity=1.0f,_yVelocity;
    private Vector3 move, velocity;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_controller.isGrounded==true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            move = new Vector3(0, 0, horizontalInput);
            velocity = move * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
