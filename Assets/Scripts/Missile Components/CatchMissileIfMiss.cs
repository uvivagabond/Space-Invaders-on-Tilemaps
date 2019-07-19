using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatchMissileIfMiss : CatchMissile
{
     private void OnTriggerEnter2D(Collider2D colliderWhichEnterTrigger)
    {
        colliderWhichEnterTrigger.gameObject.transform.parent = missilePool.transform;
        colliderWhichEnterTrigger.gameObject.SetActive(false);
        missileContainer.PutToPool(colliderWhichEnterTrigger.gameObject);
        CreateExplosionEfect();
    }
    abstract public void CreateExplosionEfect();
}
