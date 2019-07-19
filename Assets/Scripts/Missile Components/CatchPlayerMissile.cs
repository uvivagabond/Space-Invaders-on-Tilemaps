using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayerMissile : CatchMissileIfMiss
{
    protected override void Start()
    {
        base.Start();
        missileContainer = missilePool.playerMissilePool;
    }

    public override void CreateExplosionEfect()
    {
     //   Debug.Log("ExplosionEfect!");
    }
}
