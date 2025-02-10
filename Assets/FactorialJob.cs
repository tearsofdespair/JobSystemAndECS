using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class FactorialJob : IJob
{
    private int _randomNumber;
    

    public FactorialJob(int randomNumber)
    {
        _randomNumber = randomNumber;
    }

    public void Execute()
    {
        Debug.Log($"Factorial of {_randomNumber} is {GetFactorial((long)_randomNumber).ToString().TrimEnd('0')}");
    }
    
    private BigInteger GetFactorial(BigInteger f)
    {
        if(f == 0)
            return 1;
        return f * GetFactorial(f - 1);
    }
}
