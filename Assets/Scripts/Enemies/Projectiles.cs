using UnityEngine;
using UnityEngine.Events;

public class Projectiles : MonoBehaviour, IDamageableEnemy
{
    [SerializeField] protected int Health = 1;
    [SerializeField] protected float Speed = 2f;
    [SerializeField] protected Rigidbody Rigidbody;

    protected Vector3 _toPlayer; 
    protected Transform _playerTransform; // Ссылка на игрока

    public UnityEvent OnDamage;

    protected virtual void Start()
    {
        _playerTransform = FindObjectOfType<TargetForEnemies>().transform;
        
        UpdateTargetDirection();
    }
    
    protected void UpdateTargetDirection()
    {
        if (_playerTransform != null)
        {
            _toPlayer = (_playerTransform.position - transform.position).normalized;
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;

        OnDamage?.Invoke();

        if (Health <= 0)
        {
            Health = 0;

            Die();
        }
    }

    protected virtual void Move()
    {
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}