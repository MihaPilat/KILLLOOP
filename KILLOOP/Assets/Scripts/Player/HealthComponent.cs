using System;
using UnityEngine;
using Zenject;

public class HealthComponent : MonoBehaviour, IHealth
{
    private IHealth _health;

    [Inject]
    private void Construct(PlayerHealth health)
    {
        _health = health;
    }

    public bool IsAlive => _health.IsAlive;

    public event Action OnDeath
    {
        add => _health.OnDeath += value;
        remove => _health.OnDeath -= value;
    }

    public void Kill()
    {
        _health.Kill();
    }
}