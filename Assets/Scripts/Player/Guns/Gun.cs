using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform Spawn;
    
    [SerializeField] protected float ShotPeriod = 0.2f;

    [SerializeField] protected AudioSource ShotSound;
    [SerializeField] protected GameObject Flash;

    private float _timer;

    private Coroutine _flashCoroutine;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;

                Shot();
            }
        }
    }

    protected virtual void Shot()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.SetVelocity(Spawn.forward);
        ShotSound.Play();
        Flash.SetActive(true);

        _flashCoroutine = StartCoroutine(HideFlashlight());
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator HideFlashlight()
    {
        yield return new WaitForSeconds(0.08f);
        
        Flash.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_flashCoroutine != null)
        {
            StopCoroutine(_flashCoroutine);
        }
    }

    public virtual void AddBullets(int numberOfBullets)
    {
    }
}
