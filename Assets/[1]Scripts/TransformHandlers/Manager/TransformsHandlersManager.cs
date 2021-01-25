using System;
using System.Collections.Generic;
using System.Linq;
using TransformHandlers;
using UnityEngine;

public class TransformsHandlersManager : MonoBehaviour 
{
	private static TransformsHandlersManager _instance;
	
	private static readonly List<HandledTransform> _HandlersDict = new List<HandledTransform>();

	public class HandledTransform
	{
		public Transform Transform { get; }
		private Action<bool> _respond;
		private readonly List<HandlerBase> _handlers = new List<HandlerBase>();

		public HandledTransform(Transform transform) 
		{
			Transform = transform;
			if (!_HandlersDict.Contains(this)) _HandlersDict.Add(this);
		}
		
		public HandledTransform IsHaveTargetInRadius(Transform target, float distance) 
		{
			_handlers.Add(new DistanceToTargetHandler(Transform, target, distance));
			return this;
		}
		
		public HandledTransform IsHaveTargetInAngle(Transform target, float angle) 
		{
			_handlers.Add(new AngleToTargetHandler(Transform, target, angle));
			return this;
		}
		
		public HandledTransform IsInsideCameraBorders(Camera camera, float offset) 
		{
			_handlers.Add(new TransformInsideCameraViewHandler(Transform, camera, offset));
			return this;
		}

		public void RespondTo(Action<bool> respond) 
		{
			_respond = respond;
		}

		public void CalculateAllHandlers()
		{
			_respond?.Invoke(_handlers.All(item=>item.CalculateResult()));
		}
	}
	
	public static HandledTransform HandleTransform(Transform transform) 
	{
		if (_instance == null) 
		{
			var holder = new GameObject("[Transforms Handler]");
			_instance = holder.AddComponent<TransformsHandlersManager>();
			DontDestroyOnLoad(holder);
		}
		var observable = new HandledTransform(transform);

		return observable;
	}

	private void Update()
	{
		for (int index = _HandlersDict.Count - 1; index >= 0; index--)
		{
			if (_HandlersDict[index].Transform == null)
			{
				_HandlersDict.Remove(_HandlersDict[index]);
				continue;
			}

			_HandlersDict[index].CalculateAllHandlers();
		}
	}
}


