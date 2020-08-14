# Transform Helpers

- Four extensions to Transform component, to help calculate interactions with other transforms.
- And one extension to check Transform camera occlude.

# Wrapped to one Facade with Dependency Injection

- Lazy-initialization
- Supports multiple conditions
- Self-cleaning for destroyed listeners

# How to use
##### There is two ways to use extension:

## Directly call extended methods:
```
 // returns distance to transform component
transform.DistanceToTransform(Transform targetTransform)

 // returns distance to certain position
transform.DistanceToPosition(Vector3 targetPosition)

// returns angle between transform and direction
transform.GetAngleToTransform(Transform targetTransform, Vector3 direction) 

// returns angle between position and direction
transform.GetAngleToPosition(Vector3 targetPosition, Vector3 direction)

// returns true if transform inside camera view with additional offset
transform.IsInsideCameraView(Camera camera, float offset)
```

## Inject dependency in TransformsHandler:
```
 // Init handling of transform
 TransformsHandler.CheckTransform(transform)
 
 // Add angle handling 
.IsHaveTargetInAngle(Target, DetectionAngle)
 // Add distance handling
.IsHaveTargetInRadius(Target, DetectionDistance) 
 // Add camera handling
.IsInsideCameraBorders(Camera, Offset)

//Inject method-responder with bool parameter
.RespondTo(RespondingMethod);
```
##### Responding method invoked with true, when all attached handled conditions returns true
***Handler angle logics works only with transform forward**
