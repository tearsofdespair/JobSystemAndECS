using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LogarithmMonoInstaller : MonoInstaller
{
    public int Delay;

    public override void InstallBindings()
    {
        Container.Bind<int>().WithId("delay").FromInstance(Delay).AsCached().NonLazy();
    }
}
