using System;
using UnityEngine;

public interface IInput
{
    Vector2 Move { get; }
    bool Attack { get; }
}
