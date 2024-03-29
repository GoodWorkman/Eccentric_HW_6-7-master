using System;
using UnityEngine;

public class Rocket : Projectiles
{
   [SerializeField] private float _rotationSpeed = 3f;

   private Quaternion _targetRotation;

   private void Update()
   {
      UpdateTargetDirection();
      Move();
   }

   protected override void Move()
   {
      transform.position += transform.forward * (Time.deltaTime * Speed);
      
      _targetRotation = Quaternion.LookRotation(_toPlayer, Vector3.forward);
      
      transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
   }
}
