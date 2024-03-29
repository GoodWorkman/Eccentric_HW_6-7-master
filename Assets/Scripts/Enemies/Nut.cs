using UnityEngine;

public class Nut : Projectiles
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _velocity;

    protected override void Start()
    {
       Vector3 angularVelocity = new Vector3(
           Random.Range(-_rotationSpeed, _rotationSpeed),
           Random.Range(-_rotationSpeed, _rotationSpeed), 
           Random.Range(-_rotationSpeed, _rotationSpeed));
        
        Rigidbody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        Rigidbody.angularVelocity = angularVelocity;
    }
}
