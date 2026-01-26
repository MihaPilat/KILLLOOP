using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.BindInterfacesAndSelfTo<PlayerHealth>()
            .AsSingle().NonLazy();

        Container.Bind<PlayerFacade>()
         .FromComponentInHierarchy()
         .AsSingle().NonLazy();
    }

}
