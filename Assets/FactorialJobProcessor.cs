using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class FactorialJobProcessor : MonoBehaviour
{
    [Inject(Id = "delay")] private int _delay;
    [Inject(Id = "objectamount")] private int _objectAmount;
    private Random random = new Random();
    
    private void Start()
    {
        for (int i = 0; i < _objectAmount; i++)
        {
            StartCoroutine(RegurlarExcecution(_delay));
        }
    }

    public void getFactorialOfRundomNumber(int min, int max)
    {
        FactorialJob factorialJob = new FactorialJob(random.Next(min, max));
        factorialJob.Execute();
    }

    IEnumerator RegurlarExcecution(int n)
    {
        while (true)
        {
            getFactorialOfRundomNumber(0, 100);
            yield return new WaitForSeconds(n);
        }
    }

}
