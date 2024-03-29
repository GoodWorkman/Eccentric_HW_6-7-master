using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 LeftEulerRotation;
    [SerializeField] private Vector3 RightEulerRotation;

    [SerializeField] private float _rotationSpeed = 6f;

    private Transform _player;
    private Vector3 _targetEuler;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        _targetEuler = transform.position.x < _player.transform.position.x ? RightEulerRotation : LeftEulerRotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler),
            Time.deltaTime * _rotationSpeed);
    }
}