using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerDeathHandler : MonoBehaviour
{
    private IHealth _health;
    private SceneReloader _sceneReloader;

    [Inject]
    private void Construct(IHealth health, SceneReloader sceneReloader)
    {
        _sceneReloader = sceneReloader;
        _health = health;
    }
    private void OnEnable()
    {
        _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        _health.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        // звук, эффект, рестарт уровня
        Debug.Log("Player died");
        _sceneReloader.ReloadCurrent();
    }
}
