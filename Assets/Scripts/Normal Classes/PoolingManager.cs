using UnityEngine;
using System;
using System.Collections.Generic;

public class PoolingManager<T>
{
    Stack<T> pool = new Stack<T>();

    Func<T> objectGenerator;

    public PoolingManager(Func<T> generatingFunction)
    {
        if (generatingFunction == null)
        {
            Debug.LogError("The generating function is missing");
        }
        this.pool = new Stack<T>();
        this.objectGenerator = generatingFunction;
    }


    public T GetFromPool()
    {  
        if (this.pool.Count>0)
        {
            return pool.Pop();
        }
        return objectGenerator();
    }

    public void PutToPool(T item)
    {
        this.pool.Push(item);
    }
}

