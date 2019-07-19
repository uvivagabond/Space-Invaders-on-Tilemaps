using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShipArmament : VehicleArmament
{
    override public void Start()
    {
        base.Start();        
        missileContainer = missilePool.playerMissilePool;
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetAxisRaw(VirtualAxesNames.Fire1) > 0)
        {    
            if (transform.childCount==0)
            {
                Shoot();
            }            
        }
    }

    public override void Shoot()
    {
        GameObject missile = base.InitializeMissile(new Vector3(0, missileSpeed, 0));
    }
}
