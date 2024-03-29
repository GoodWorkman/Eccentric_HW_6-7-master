#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _distanceToActivate = 20f;

    private bool _isActive = true;
    private ActivatorForEnemies _activator;
    private float _distance;
    private float _distanceCorrection = 2f;

    private void Start()
    {
        _activator = FindObjectOfType<ActivatorForEnemies>();
        
        _activator.AddEnemyToList(this);
    }
    
    private void OnDestroy()
    {
        _activator.RemoveEnemyFromList(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        _distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (_distance > _distanceToActivate + _distanceCorrection)
            {
                Deactivate();
            }
        }
        else
        {
            if (_distance < _distanceToActivate)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        _isActive = true;
        
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        _isActive = false;
        
        gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.magenta;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
#endif
    
}
