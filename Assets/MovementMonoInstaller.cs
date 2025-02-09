using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementMonoInstaller : MonoInstaller
{
    public GameObject Prefab;
    public float Speed;
    public int SpawnCount;
    public float Radius;
    
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(Prefab).AsSingle().NonLazy();
        Container.Bind<float>().WithId("speed").FromInstance(Speed).AsCached().NonLazy();
        Container.Bind<int>().WithId("objectamount").FromInstance(SpawnCount).AsCached().NonLazy();
        Container.Bind<float>().WithId("radius").FromInstance(Radius).AsCached().NonLazy();
    }
}
