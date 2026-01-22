using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;
    public override void InstallBindings()
    {
        BindInput();
        BindPlayerConfig();
        BindSceneReload();
    }

    private void BindSceneReload()
    {
        Container.Bind<SceneReloader>().AsSingle().NonLazy();
    }

    private void BindPlayerConfig()
    {
        Container.Bind<PlayerConfig>()
            .FromInstance(_playerConfig)
            .AsSingle()
            .NonLazy();
    }

    private void BindInput()
    {
        Container.BindInterfacesTo<InputReader>().AsSingle().NonLazy();
    }
}
