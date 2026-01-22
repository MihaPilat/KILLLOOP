using System;
public interface IHealth
{
    event Action OnDeath;
    bool IsAlive { get; }
    void Kill();
}
