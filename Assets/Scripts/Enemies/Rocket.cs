using System;
using UnityEngine;

public class Rocket : Projectiles
{
    [SerializeField] private float _rotationSpeed = 3f;

    private Quaternion _targetRotation;
    private Vector3 _position;

    private void Update()
    {
        UpdateTargetDirection();
        Move();
    }

    protected override void Move()
    {
        _position = transform.position;
        _position += transform.forward * (Time.deltaTime * Speed);
        _position.z = 0;
        transform.position = _position;

        _targetRotation = Quaternion.LookRotation(_toPlayer, Vector3.right);

        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
    }
}