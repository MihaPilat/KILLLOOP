using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _speed;

    private Rigidbody2D _rb;
    private IInput _input;
    private PlayerConfig _playerConfig;

    [Inject]
    private void Constract(IInput input, PlayerConfig playerConfig)
    {
        _input = input;
        _playerConfig = playerConfig;
        _speed = _playerConfig.MoveSpeed;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 move = _input.Move.normalized;

        Vector2 targetPosition = _rb.position + move * _speed * Time.fixedDeltaTime;

        _rb.MovePosition(targetPosition);
    }
}
