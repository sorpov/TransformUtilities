using UnityEngine;

namespace TransformHandlers
{
	public abstract class HandlerBase
	{
		protected readonly Transform Transform;
		protected HandlerBase(Transform transform) 
		{
			Transform = transform;
		}

		public abstract bool CalculateResult();

	}
}