using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;
    [SerializeField] private Transform _rayStart;

    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;

    [SerializeField] private Direction _currentDirection;

    public UnityEvent OnLeftTarget;
    public UnityEvent OnRightTarget;

    private bool _isStopped;
    private Vector3 _direction;
    private Coroutine _coroutine;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;

        _direction = new Vector3(Time.deltaTime * _speed, 0f, 0f);
    }

    private void Update()
    {
        if (_isStopped) return;

        if (_currentDirection == Direction.Left)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        
        MagnetToGround();
    }

    private void MoveLeft()
    {
        transform.position -= _direction;

        if (transform.position.x <= _leftTarget.position.x)
        {
            _currentDirection = Direction.Right;
            _isStopped = true;

            _coroutine = StartCoroutine(ContinueWalk());
            
            OnLeftTarget?.Invoke();
        }
    }

    private void MoveRight()
    {
        transform.position += _direction;
        
        if (transform.position.x >= _rightTarget.position.x)
        {
            _currentDirection = Direction.Left;
            _isStopped = true;

            _coroutine = StartCoroutine(ContinueWalk());
            
            OnRightTarget?.Invoke();
        }
    }

    private IEnumerator ContinueWalk()
    {
        yield return new WaitForSeconds(_stopTime);

        _isStopped = false;
    }

    private void MagnetToGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void OnDestroy()
    {
        if (_coroutine != null)
        {
           StopCoroutine(_coroutine);
        }
    }
}
