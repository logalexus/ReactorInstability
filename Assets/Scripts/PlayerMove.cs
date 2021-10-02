using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;

    private float _verticalInput;
    private float _horizontalInput;
    private float _speed = 10f;


    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical") * _speed;
        _horizontalInput = Input.GetAxis("Horizontal") * _speed;
    }

    private void FixedUpdate()
    {
        _player.velocity = new Vector2(_horizontalInput, _player.velocity.y);
        _player.velocity = new Vector2(_player.velocity.x, _verticalInput);
        
    }
}
