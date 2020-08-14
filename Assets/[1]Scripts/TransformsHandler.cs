using System;
using System.Collections.Generic;
using UnityEngine;

public class TransformsHandler : MonoBehaviour 
{
	private static TransformsHandler _instance;
	
	private static readonly Dictionary<HandledTransform,  List<Handler>> HandlersDict = new Dictionary<HandledTransform,  List<Handler>>();

	#region Hanlders

	private class Handler 
	{
		protected readonly Transform Transform;
		protected Handler(Transform transform) 
		{
			Transform = transform;
		}

		public virtual bool CalculateResult() 
		{
			return false;
		}
	}

	private class TargetHandler : Handler 
	{
		protected readonly Transform Target;
		protected TargetHandler(Transform transform, Transform target) : base(transform) 
		{
			Target = target;
		}
	}

	private class DistanceToTransform : TargetHandler 
	{
		private readonly float _distance;
		public DistanceToTransform(Transform transform, Transform target, float distance) : base(transform, target) 
		{
			_distance = distance;
		}

		public override bool CalculateResult() 
		{
			return Transform.DistanceToTransform(Target) <= _distance;
		}
	}

	private class AngleToTransform : TargetHandler 
	{
		private readonly float _angle;
		private readonly Vector3 _direction;
		public AngleToTransform(Transform transform, Transform target, float angle) : base(transform, target) 
		{
			_angle = angle;
		}

		public override bool CalculateResult() 
		{
			return Transform.GetAngleToTransform(Target, Transform.forward) <= _angle;
		}
	}

	private class IsInsideCameraView : Handler 
	{
		private readonly Camera _camera;
		private readonly float _offset;
		public IsInsideCameraView(Transform transform, Camera camera, float offset) : base(transform) 
		{
			_camera = camera;
			_offset = offset;
		}

		public override bool CalculateResult() 
		{
			return Transform.IsInsideCameraView(_camera, _offset);
		}
	}

	#endregion
	
	public class HandledTransform 
	{
		public Transform Transform { get; }
		private bool IsAllCorrect;
		public Action<bool> Respond;

		public HandledTransform(Transform transform) 
		{
			Transform = transform;
			if (!HandlersDict.ContainsKey(this)) HandlersDict.Add(this, new List<Handler>());
		}
		
		public HandledTransform IsHaveTargetInRadius(Transform target, float distance) 
		{
			HandlersDict[this].Add(new DistanceToTransform(Transform, target, distance));
			return this;
				
		}
		
		public HandledTransform IsHaveTargetInAngle(Transform target, float angle) 
		{
			HandlersDict[this].Add(new AngleToTransform(Transform, target, angle));
			return this;
		}
		
		public HandledTransform IsInsideCameraBorders(Camera camera, float offset) 
		{
			HandlersDict[this].Add(new IsInsideCameraView(Transform, camera, offset));
			return this;
		}

		public void RespondTo(Action<bool> respond) 
		{
			Respond = respond;
		}

	}
	
	public static HandledTransform CheckTransform(Transform transform) 
	{
		if (_instance == null) 
		{
			var holder = new GameObject("[Transforms Handler]");
			_instance = holder.AddComponent<TransformsHandler>();
			DontDestroyOnLoad(holder);
		}
		var observable = new HandledTransform(transform);

		return observable;
	}

	private void Update() {
		foreach (var item in HandlersDict) 
		{
			if (item.Key.Transform == null) 
			{
				HandlersDict.Remove(item.Key);
				continue;
			}
			var respond = true;
			for (var i = 0; i < HandlersDict[item.Key].Count; i++) 
			{
				if (!HandlersDict[item.Key][i].CalculateResult()) respond = false;
			}

			item.Key.Respond?.Invoke(respond);
		}
	}
}


