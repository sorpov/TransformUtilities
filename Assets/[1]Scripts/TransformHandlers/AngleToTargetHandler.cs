using UnityEngine;

namespace TransformHandlers
{
	public class AngleToTargetHandler : TargetHandlerBase 
	{
		private readonly float _angle;
		private readonly Vector3 _direction;
		public AngleToTargetHandler(Transform transform, Transform target, float angle) : base(transform, target) 
		{
			_angle = angle;
		}

		public override bool CalculateResult() 
		{
			return Transform.GetAngleToTransform(Target, Transform.forward) <= _angle;
		}
	}
}