using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public struct MovementJOB : IJobParallelForTransform
{
    private float _speed;
    private float _radius;
    private Vector3 _center;

    public MovementJOB(float speed, float radius, Vector3 center)
    {
        _speed = speed;
        _radius = radius;
        _center = center;
    }

     

    public void Execute(int index, TransformAccess transform)
    {
        Vector3 r = Quaternion.AngleAxis(_speed, Vector3.forward) * Vector3.up;
        // The center of the center + radius = the point on the round
        transform.position += _center + r;

        
    }
}
