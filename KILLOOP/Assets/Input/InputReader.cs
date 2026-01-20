using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputReader : IInitializable, IInput
{
    public Vector2 Move  { get; private set; }

    private PlayerInputActions _input;
    public void Initialize()
    {
        _input = new PlayerInputActions();
        _input.Enable();
        _input.Player.Move.performed += ctx => Move = ctx.ReadValue<Vector2>();
        _input.Player.Move.canceled += _ => Move = Vector2.zero;
    }
}
