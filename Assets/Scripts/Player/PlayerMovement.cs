using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;
    private Vector3 _normalizeDirection= new Vector3(1,0,0);
    private Vector3 _gravity = new Vector3(0, -9.8f, 0);

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) & _isGrounded)
            Jump();    
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
        _isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ground>())    
            _isGrounded = true;       
    }
} 