using UnityEngine;

public class EnemyAi : MonoBehaviour 
{
    [SerializeField] protected Transform Target;
    protected Transform ThisTransform;
    
    protected static Camera MainCamera;
    
	protected virtual void Start() 
	{
        if (!MainCamera) MainCamera = Camera.main;
        ThisTransform = transform;
	}
}
