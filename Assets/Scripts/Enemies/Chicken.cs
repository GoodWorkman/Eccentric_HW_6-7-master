using UnityEngine;

public class Chicken : Enemy
{
   
    [SerializeField] private float TimeToReachSpeed = 1f;
    
    private Transform _playerTransform; // в дальнейшем курица будет префаб, поэтому будет искать игрока


    private void Start()
    {
       _playerTransform = FindObjectOfType<TargetForEnemies>().transform;
    }

    void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;
        
        Rigidbody.AddForce(force);
    }
}
