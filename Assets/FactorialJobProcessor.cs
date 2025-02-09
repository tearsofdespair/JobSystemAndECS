using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using Random = System.Random;

public class FactorialJobProcessor : MonoBehaviour
{
    public int N;
    public int ObjectAmount;
    private Random random = new Random();

    private void Start()
    {
        for (int i = 0; i < ObjectAmount; i++)
        {
            StartCoroutine(RegurlarExcecution(N));
        }
    }

    public void getFactorialOfRundomNumber(int min, int max)
    {
        FactorialJob factorialJob = new FactorialJob(random.Next(min, max), N);
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
