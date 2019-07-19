using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchEnemyMissile : CatchMissileIfMiss
{
    override protected void Start()
    {
        base.Start();
        missileContainer = missilePool.enemyMissilePool;
    }

    public override void CreateExplosionEfect()
    {
    }
}
