using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;

    private float _verticalInput;
    private float _horizontalInput;
    private float _speed = 5f;
    private bool _isMove = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GameController.Instance.StartGame += () => _isMove = true;
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical") * _speed;
        _horizontalInput = Input.GetAxis("Horizontal") * _speed;
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            _player.velocity = new Vector2(_horizontalInput, _player.velocity.y);
            _player.velocity = new Vector2(_player.velocity.x, _verticalInput);
        }
        PlayAnimation();
    }

    public void StopMove()
    {
        _player.velocity = Vector3.zero; 
        PlayAnimation();
        _animator.SetBool("Fix", true);
    }

    private void PlayAnimation()
    {
        _animator.SetBool("Fix", false);
        if (_player.velocity.x != 0)
            _animator.SetFloat("Speed", _player.velocity.x);
        else _animator.SetFloat("Speed", _player.velocity.y);
    }
}
