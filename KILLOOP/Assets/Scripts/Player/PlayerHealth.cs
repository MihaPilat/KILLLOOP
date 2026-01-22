using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : IHealth
{
    public event Action OnDeath;
    public bool IsAlive { get; private set; } = true;

    public void Kill()
    {
        if (!IsAlive) return;

        IsAlive = false;
        OnDeath?.Invoke();
    }
}
