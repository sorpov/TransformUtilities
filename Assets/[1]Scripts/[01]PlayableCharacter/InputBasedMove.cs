using UnityEngine;

public class InputBasedMove : MonoBehaviour {
    [SerializeField] private float Speed = 10;
    private Transform _transform;

    private void Start() => _transform = transform;

    private void Update() 
    {
        _transform.position += Speed * Time.deltaTime 
                               * (Vector3.forward * Input.GetAxis("Horizontal") + Vector3.left * Input.GetAxis("Vertical"));
    }
}
