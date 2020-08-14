using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float SmoothTime = 0.3F;

    private Transform _transform;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _offset;

    private void Start() 
    {
        _transform = transform;
        _offset = _transform.position - Target.position;
    }

    private void Update()
    {
        var targetPosition = Target.position + _offset;
        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, SmoothTime);
    }
}
