
using UnityEngine;

public class Carrot : Projectiles
{
    protected override void Start()
    {
        base.Start();
        transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        Rigidbody.velocity = _toPlayer * Speed;
    }
}