using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageableEnemy
{
    [SerializeField] protected int Health = 1;
    [SerializeField] protected float Speed = 2f;
    [SerializeField] protected Rigidbody Rigidbody;

    public UnityEvent OnDamage;

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