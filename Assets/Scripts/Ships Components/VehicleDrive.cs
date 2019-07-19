using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleDrive : ShipBase, IMove
{
    public float speedOfmovement = 1;
    protected new Rigidbody2D rigidbody;


    virtual public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    abstract public void Move();

    void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;
    }
}
