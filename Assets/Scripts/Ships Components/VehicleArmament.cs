using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleArmament : ShipBase, IShoot
{
    public float missileSpeed = 5;
    protected PoolingManager<GameObject> missileContainer;
    protected MissilePool missilePool;

    virtual public void Start()
    {
        missilePool = GameObject.FindGameObjectWithTag("PoolContainer").GetComponent<MissilePool>();
    }

    abstract public void Shoot();


    protected GameObject InitializeMissile(Vector3 velocity)
    {
        GameObject missile = missileContainer.GetFromPool();
        missile.SetActive(true);
        ResetMissilePosition(missile);
        missile.GetComponent<Rigidbody2D>().velocity = velocity;
        return missile;
    } 

    void ResetMissilePosition(GameObject missile)
    {
        missile.transform.parent = transform;
        missile.transform.localPosition = Vector3.zero;
    }

  

}
