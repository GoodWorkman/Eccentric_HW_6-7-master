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
        Enemy enemy = collider.GetComponentInParent<Enemy>();
       
        if (enemy != null)
        {
            enemy.TakeDamage(_damageValue); 
            InstantiateEffectAndDestroy();
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
