using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private Rigidbody _rigidbody;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetVelocity(Vector3 direction)
    {
        _rigidbody.velocity = direction * _bulletSpeed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }
    
    private void HandleCollision(Collider collider)
    {
        IDamageableEnemy damageable = collider.GetComponentInParent<IDamageableEnemy>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damageValue);
            InstantiateEffectAndDestroy();
            return; 
        }

        if (collider.isTrigger == false)
        {
            InstantiateEffectAndDestroy();
        }
    }
    
    private void InstantiateEffectAndDestroy()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
