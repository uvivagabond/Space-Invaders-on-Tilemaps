using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatchMissile : MonoBehaviour
{
    protected PoolingManager<GameObject> missileContainer;
    protected MissilePool missilePool;

    protected virtual void Start()
    {
        missilePool = GameObject.FindGameObjectWithTag("PoolContainer").GetComponent<MissilePool>();
    }
}
