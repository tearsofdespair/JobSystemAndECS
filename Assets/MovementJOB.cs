using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public struct MovementJOB : IJobParallelForTransform
{
    private float _speed;
    private float _radius;
    

    public MovementJOB(float speed, float radius)
    {
        _speed = speed;
        _radius = radius;
        
    }

     

    public void Execute(int index, TransformAccess transform)
    {
        float currentAngle = Mathf.Atan2(transform.position.y, transform.position.x);
        float newAngle = currentAngle + _speed;
        Vector3 newPosition = new Vector3(Mathf.Cos(newAngle) * _radius, Mathf.Sin(newAngle) * _radius, transform.position.z);
        transform.position = newPosition;

        
    }
}
