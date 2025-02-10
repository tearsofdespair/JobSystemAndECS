using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class LogarithmJob : IJob
{
    private int _randomNumber;
    

    public LogarithmJob(int randomNumber)
    {
        _randomNumber = randomNumber;
    }

    public void Execute()
    {
        Debug.Log($"Logarithm of {_randomNumber} is {Math.Log(_randomNumber)}");
    }
    
    
}
