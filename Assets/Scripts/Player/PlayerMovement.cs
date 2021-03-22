using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private Player _player;
    private bool _grounded=false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
            _grounded = true;
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.Dying += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Dying -= OnPlayerDied;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_speed, _rigidbody.velocity.y, 0);
        if (Input.GetKey(KeyCode.Space)&&_grounded)
        {
            Jump();
        }
    }

    private void OnPlayerDied()
    {
        _speed = 0;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
        _grounded = false;
    }
}