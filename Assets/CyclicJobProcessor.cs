using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using Zenject;

public class CyclicJobProcessor : MonoBehaviour
{
     private GameObject _prefab;
     [Inject(Id = "speed")] private float _speed;
     [Inject(Id = "objectamount")] private int _spawnCount;
     [Inject(Id = "radius")] private float _radius;

    [Inject]
    public void Construct(GameObject prefab)
    {
        this._prefab = prefab;
        Debug.Log("hueta");
    }

    private Transform[] _transforms;
    private TransformAccessArray _transformAccessArray;

    NativeArray<int> _numberLogs;

    private void Update()
    {
        HandleMovementJob();
    }

    // Start is called before the first frame update
    void Start()
    {
        _transforms = new Transform[_spawnCount];
        for(int i = 0; i < _spawnCount; i++)
        {
            Transform instanceTransform = Instantiate(_prefab, Vector3.zero, Quaternion.identity).transform;
            _transforms[i] = instanceTransform;
        }
        _transformAccessArray = new TransformAccessArray(_transforms);
        _numberLogs = new NativeArray<int>(_spawnCount, Allocator.Persistent);
    }

    private void HandleMovementJob()
    {
        MovementJOB movementJob = new MovementJOB(_speed, _radius);
        JobHandle jobHandle = movementJob.Schedule(_transformAccessArray);
        jobHandle.Complete();
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
        _numberLogs.Dispose();
    }

}
