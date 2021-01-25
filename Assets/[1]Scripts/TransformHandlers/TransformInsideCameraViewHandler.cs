using UnityEngine;

namespace TransformHandlers
{
	public class TransformInsideCameraViewHandler : HandlerBase 
	{
		private readonly Camera _camera;
		private readonly float _offset;
		public TransformInsideCameraViewHandler(Transform transform, Camera camera, float offset) : base(transform) 
		{
			_camera = camera;
			_offset = offset;
		}

		public override bool CalculateResult() 
		{
			return Transform.IsInsideCameraView(_camera, _offset);
		}
	}
}