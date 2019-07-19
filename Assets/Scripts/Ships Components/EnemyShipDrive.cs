using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipDrive : VehicleDrive, IMove
{ 
    public float deltaDown = 0.1f;
    float direction = 1;
    float frequancyModifier = 6.28f;
    int iteration = 1;

    override public void Start()
    {
        base.Start();      
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirectionOfEnemysMove(collision);
    }

    private void ChangeDirectionOfEnemysMove(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            direction *= -1;
            transform.position -= Vector3.up * deltaDown;
            speedOfmovement += 0.5f * iteration;
        }
    }

    override public void Move()
    {
        float jerkyMovementSpeed = Mathf.Sign(Mathf.Sin( Time.time * frequancyModifier))>0 ? 1f : 0f;
        rigidbody.velocity = new Vector3(speedOfmovement * direction* jerkyMovementSpeed, 0, 0);       
    }   
}

