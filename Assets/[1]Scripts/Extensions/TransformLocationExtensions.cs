using UnityEngine;

public static class TransformLocationExtensions
{
    public static float DistanceToTransform(this Transform transform, Transform targetTransform) 
    {
        return transform.DistanceToPosition(targetTransform.position);
    }
    
    public static float DistanceToPosition(this Transform transform, Vector3 targetPosition) 
    {
        return Vector3.Distance(transform.position, targetPosition);
    }

    public static bool IsInsideCameraView(this Transform transform, Camera camera, float offset = 0f) 
    {
        var point = camera.WorldToViewportPoint(transform.position);
        return point.x > 0 - offset && point.x < 1 + offset && point.y > 0 - offset && point.y < 1 + offset;
    }

    public static float GetAngleToTransform(this Transform transform, Transform targetTransform, Vector3 direction) 
    {
        return transform.GetAngleToPosition(targetTransform.position, direction);
    }
    
    public static float GetAngleToPosition(this Transform transform, Vector3 targetPosition, Vector3 direction) 
    {
        var directionToPosition = targetPosition - transform.position;
        return Vector3.Angle(directionToPosition, direction);
    }
}
