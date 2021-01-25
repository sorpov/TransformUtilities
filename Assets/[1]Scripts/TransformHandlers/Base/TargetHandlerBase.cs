using UnityEngine;

namespace TransformHandlers
{
	public abstract class TargetHandlerBase : HandlerBase
	{
		protected readonly Transform Target;
		protected TargetHandlerBase(Transform transform, Transform target) : base(transform) 
		{
			Target = target;
		}
	}
}