using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class CyclicJobProcessor : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float speed;
    [SerializeField] private int spawnCount;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 center;

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
        _transforms = new Transform[spawnCount];
        for(int i = 0; i < spawnCount; i++)
        {
            Transform instanceTransform = Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
            _transforms[i] = instanceTransform;
        }
        _transformAccessArray = new TransformAccessArray(_transforms);
        _numberLogs = new NativeArray<int>(spawnCount, Allocator.Persistent);
    }

    private void HandleMovementJob()
    {
        MovementJOB movementJob = new MovementJOB(speed, radius, center);
        JobHandle jobHandle = movementJob.Schedule(_transformAccessArray);
        jobHandle.Complete();
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
        _numberLogs.Dispose();
    }

}
