using UnityEngine;

public class SetTriggerEveryNSecond : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _shootRate = 4f;
    [SerializeField] private string _triggerName = "Attack";

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _shootRate)
        {
            _timer = 0;
            
            _animator.SetTrigger(_triggerName);
        }
    }
}
