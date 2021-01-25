using UnityEngine;

namespace TransformHandlers
{
	public class DistanceToTargetHandler : TargetHandlerBase 
	{
		private readonly float _distance;
		public DistanceToTargetHandler(Transform transform, Transform target, float distance) : base(transform, target) 
		{
			_distance = distance;
		}

		public override bool CalculateResult() 
		{
			return Transform.DistanceToTransform(Target) <= _distance;
		}
	}
}