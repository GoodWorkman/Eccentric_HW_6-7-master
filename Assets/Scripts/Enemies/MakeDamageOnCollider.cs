using System;
using UnityEngine;

public class MakeDamageOnCollider : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private bool handleCollision = true;
    [SerializeField] private bool handleTrigger = true;
    [SerializeField] private bool destroyOnAnyCollision = false;
    
    private IDamageableEnemy _damageableEnemy;
    private bool hasCollided = false; // Флаг для проверки первого столкновения
    private int _destroyDamageValue = 100;

    private void Start()
    {
        _damageableEnemy = GetComponentInParent<IDamageableEnemy>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollided) return;
        
        if (handleCollision)
        {
            HandleCollision(collision.collider);
        }
        
        CheckCollisionConditions(collision.collider);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (hasCollided) return;
        
        if (handleTrigger)
        {
            HandleCollision(other);
        }
        
        CheckCollisionConditions(other);
    }
    
    private void CheckCollisionConditions(Collider collider)
    {
        if (destroyOnAnyCollision)
        {
            if (collider.isTrigger == false)
            {
                _damageableEnemy.TakeDamage(_destroyDamageValue);
            }
        }
    }
    
    private void HandleCollision(Collider collider)
    {
        PlayerHealth playerHealth = collider.GetComponentInParent<PlayerHealth>();
       
        if (playerHealth)
        {
            hasCollided = true; // Устанавливаем флаг, так как урон нанесен
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        hasCollided = false; // Сбрасываем флаг при выходе из столкновения
    }

    private void OnTriggerExit(Collider other)
    {
        hasCollided = false; // Сбрасываем флаг при выходе из триггера
    }
}
