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
        float currentAngle = Mathf.Atan2(transform.position.y, transform.position.x);
        float newAngle = currentAngle + _speed;
        Vector3 newPosition = new Vector3(Mathf.Cos(newAngle) * _radius, Mathf.Sin(newAngle) * _radius, transform.position.z);
        transform.position = newPosition;

        
    }
}
