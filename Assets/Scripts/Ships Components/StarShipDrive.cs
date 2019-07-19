using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StarShipDrive : VehicleDrive
{
    public override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        float actualSpeed = Input.GetAxisRaw("Horizontal") * speedOfmovement;
        rigidbody.velocity = new Vector3(actualSpeed, 0, 0);
    }

    public void ReturnToStartPosition()
    {
        transform.position = new Vector3(9.4f, -8.24f);
    }
}

